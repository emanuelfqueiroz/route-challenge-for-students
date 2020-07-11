using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FindRouteFromZero.Application.Routes.FindBestRoute;
 using FindRouteFromZero.Domain.Models;
using Algorithms.ShortestPath.Dijkstra;

namespace FindRouteFromZero.Application.Routes.Finder
{
   public  class DijkstraAdapter : IFinderShortestPath
    {

        public RouteResponse BestRouteAsync(string from, string to, List<Route> routes)
        {
            try
            {
                Graph graph = ConvertToGraph(routes);
                var pathFinder = new PathFinder(graph);

                var path = pathFinder.FindShortestPath(
                    graph.Nodes.Single(node => node.Id == from),
                    graph.Nodes.Single(node => node.Id == to));
                return new RouteResponse()
                {
                    Routes = path.Segments.Select<PathSegment, string>(s => $"{s.Origin.Id} > {s.Destination.Id} : Cost {s.Weight}").ToList(),
                    TotalCost = Convert.ToDecimal(path.Segments.Sum(s => s.Weight))
                };
            }
            catch (NoPathFoundException e)
            {
                return null;
            }
            catch (Exception exc)
            {
                if (exc.Message.Equals("Sequence contains no matching element", StringComparison.InvariantCultureIgnoreCase))
                {
                    return null;
                }
                throw exc;
            }

        }

        private static Graph ConvertToGraph(List<Route> routes)
        {
            var builder = new GraphBuilder();

            var allLocations = routes.SelectMany<Route, string>(r =>
                new string[] { r.From, r.To }
            ).Distinct();
            foreach (var location in allLocations)
            {
                builder.AddNode(location);
            }

            foreach (var route in routes)
            {
                builder.AddLink(sourceId: route.From, destinationId: route.To,weight: Convert.ToDouble(route.Cost));
            }

            var graph = builder.Build();
            return graph;
        }

        public Route Map(PathSegment p)
        {
            return new Route()
            {
                Cost = Convert.ToDecimal(p.Weight),
                From = p.Origin.Id,
                To = p.Destination.Id
            };
        }
    }
}
