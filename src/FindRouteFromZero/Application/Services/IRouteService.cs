using FindRouteFromZero.Application.Routes.FindBestRoute;
using System.Threading.Tasks;

namespace FindRouteFromZero.Application.Services
{
    public interface IRouteService
    {
        Task<RouteReponse> FindBestRoute(RouteRequest routeRequest);
    }
}
