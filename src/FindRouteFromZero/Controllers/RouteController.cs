using FindRouteFromZero.Application.Routes.FindBestRoute;
using FindRouteFromZero.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FindRouteFromZero.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        public IRouteService _service { get; set; }

        public RouteController(IRouteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<RouteReponse>> GetBestRoute([FromQuery] RouteRequest routeRequest)
        {
            return Ok(await _service.FindBestRoute(routeRequest));
        }
    }
}