using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TouristChallenge1.Application.DS;
using TouristChallenge1.Application.Dtos;
using TouristChallenge1.Application.Interfaces;
using TouristChallenge1.Domain.Models;
using TouristChallenge1.InfraStructure.Data;


namespace TouristChallenge1.Controllers
{
    public class RouteController : Controller
    {
        IWebHostEnvironment _env;
        public IRouteService _service { get; set; }

        public RouteController(IWebHostEnvironment env, IRouteService service)
        {
            _env = env;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> FindBestRoute(FindRouteRequest request)
        {
            // Our dictionary of nodes. Allows us to quickly change a nodes value
            // through its name (the key).
            string fileName = "routes.csv";
             Dictionary<string, Node> nodeDict = new Dictionary<string, Node>();
            // The list of routes.
             List<Route> routes = new List<Route>();

            // This set allows us to quickly check which nodes we have already
            // visited.
             HashSet<string> unvisited = new HashSet<string>();

            var fileSrcObject = Path.Combine(_env.WebRootPath, $"Sources/{fileName}");
            using (var reader = new StreamReader(fileSrcObject))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.IgnoreBlankLines = true;
                csv.Configuration.IgnoreQuotes = true;
                var records = csv.GetRecords<RouteCsv>();
                
                var (from, to, cost) = (csv.GetField<string>("Origin"), csv.GetField<string>("Destination"), csv.GetField<decimal>("Cost"));
                if (!nodeDict.ContainsKey(from)) { nodeDict.Add(from, new Node(from)); }
                if (!nodeDict.ContainsKey(to)) { nodeDict.Add(to, new Node(to)); }
                unvisited.Add(from);
                unvisited.Add(to);

                routes.Add(new Route(from, to, cost));

               
                Debug.WriteLine("Nodes(Vertices):");
                foreach (Node node in nodeDict.Values)
                {
                  Debug.WriteLine($"\t{node.Name}");
                }
                Debug.WriteLine("\nRoutes:");
                foreach (Route route in routes)
                {
                  Debug.WriteLine("\t" + route.From + " -> " + route.To + " Distance: " + route.Cost);
                }

               
                
                string startNode = request.From;
                string destNode = request.To;

                PriorityQueueCollection queue = new PriorityQueueCollection();
                string destinationNode;
                    // If there are no nodes left to check in our queue, we're done.
                    if (queue.Count == 0)
                    {
                       // return;
                    }

                    foreach (var route in routes.FindAll(r => r.From == queue.First.Value.Name))
                    {
                        // Skip routes to nodes that have already been visited.
                        if (!unvisited.Contains(route.To))
                        {
                            continue;
                        }

                        decimal travelledDistance = nodeDict[queue.First.Value.Name].Value + route.Cost;

                        // We only look at nodes we haven't visited yet and we only
                        // update the node's values if the distance of the path we're
                        // currently checking is shorter than the one we found before.
                        if (travelledDistance < nodeDict[route.To].Value)
                        {
                            nodeDict[route.To].Value = travelledDistance;
                            nodeDict[route.To].PreviousNode = nodeDict[queue.First.Value.Name];
                        }

                        // We don't add the 'to' node to the queue if it has already been
                        // visited and we don't allow duplicates.
                        if (!queue.HasInitial(route.To))
                        {
                            queue.AddNodeWithPriority(nodeDict[route.To]);
                        }
                    }
                    unvisited.Remove(queue.First.Value.Name);
                    queue.RemoveFirst();

                // CheckNode(queue, destinationNode);


                // Starts with the destination node and basically adds all the nodes'
                // respective previous nodes to a list, which is then reversed and
                // printed out.
               // string startNode; string destNode;
                    var pathList = new List<String> { destNode };

                    Node currentNode = nodeDict[destNode];
                    while (currentNode != nodeDict[startNode])
                    {
                        pathList.Add(currentNode.PreviousNode.Name);
                        currentNode = currentNode.PreviousNode;
                    }

                    pathList.Reverse();
                    for (int i = 0; i < pathList.Count; i++)
                    {
                        Debug.Write(pathList[i] + (i < pathList.Count - 1 ? " -> " : "\n"));
                    }
                    Debug.WriteLine("Overall distance: " + nodeDict[destNode].Value);
                


                // return await Task.FromResult(records.ToList());
                //.Map()).ToList()); .Select(p => p.Map()).ToList())
            }

            return Ok(await _service.FindBestRoute(request));
        }
    }
}