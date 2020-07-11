using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.ShortestPath.Dijkstra;
using FindRouteFromZero.Application.Routes.FindBestRoute;
using FindRouteFromZero.Application.Routes.Finder;
using FindRouteFromZero.Application.Services;
using FindRouteFromZero.Domain.Models;
using FindRouteFromZero.Domain.Repositories;

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

        public async Task<RouteResponse> FindBestRoute(RouteRequest routeRequest)
        {
            List<Route> routes = await _repository.GetAllRoutes();
            var response = _finder.BestRouteAsync(routeRequest.From, routeRequest.To, routes);
            return await Task.FromResult(response);
        }
    }
}
