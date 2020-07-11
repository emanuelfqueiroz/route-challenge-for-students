using FindRouteFromZero.Application.Routes.FindBestRoute;
using System.Threading.Tasks;

namespace FindRouteFromZero.Application.Services
{
    public interface IRouteService
    {
        Task<RouteResponse> FindBestRoute(RouteRequest routeRequest);
    }
}
