using FindRouteFromZero.Application.Routes.FindBestRoute;
using FindRouteFromZero.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindRouteFromZero.Application.Routes.Finder
{
    public interface IFinderShortestPath
    {
        RouteReponse BestRouteAsync( string from, string to, List<Route> routes);
    }
}