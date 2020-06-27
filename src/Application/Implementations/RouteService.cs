using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetDomain.Mvc;
using Microsoft.AspNetDomain.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristChallenge1.Application.Dtos;
using TouristChallenge1.Application.Interfaces;
using TouristChallenge1.Domain.Repositories;

namespace TouristChallenge1.Application.Implementations
{
    public class RouteService : IRouteService
    {
        public IRouteRepository _repo { get; set; }

        public RouteService(IRouteRepository repo)
        {
            _repo = repo;
        }

        public async Task<RouteResponse> FindBestRoute(FindRouteRequest request)
        {
            List<Route> routes = await _repo.GetAllAsync();
            return new RouteResponse()
            {

            };
        }
    }
}
