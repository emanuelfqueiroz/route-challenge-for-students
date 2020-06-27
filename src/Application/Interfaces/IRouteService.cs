
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristChallenge1.Application.Dtos;

namespace TouristChallenge1.Application.Interfaces
{
    public interface IRouteService
    {
        Task<RouteResponse> FindBestRoute(FindRouteRequest request);
    }
}
