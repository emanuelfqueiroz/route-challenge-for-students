using Algorithms.ShortestPath.Dijkstra;
using FindRouteFromZero.Application.Routes.FindBestRoute;
using FindRouteFromZero.Application.Routes.Finder;
using FindRouteFromZero.Application.Services;
using FindRouteFromZero.Domain.Models;
using FindRouteFromZero.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRouteFromZero.Application.Routes
{
    public class RouteService : IRouteService
    {
        public IRouteRepository _repository { get; set; }
        public IFinderShortestPath _finder { get; set; }

        public RouteService(IRouteRepository repository, IFinderShortestPath finder)
        {
            _repository = repository;
            _finder = finder;
        }

        public async Task<RouteReponse> FindBestRoute(RouteRequest routeRequest)
        {
            // 1 - Get Routes From Source: "csv" | [Graph database - Neo4J, Sql Server ]
            List<Route> routes = await _repository.GetAllRoutes();

            // 2 - Processing the best route
            
            //Why I am using Sinchronous method?
            var reponse =  _finder.BestRouteAsync(routeRequest.From, routeRequest.To, routes);
            return await Task.FromResult(reponse);

            //return await Task.FromResult(new RouteReponse()
            //{
            //    Routes = routes.Select(p => p.From).Distinct().ToList(),
            //    TotalCost = 10
            //});
        }
    }
}
