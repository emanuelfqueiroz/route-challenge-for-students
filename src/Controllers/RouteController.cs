using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TouristChallenge1.Application.Dtos;
using TouristChallenge1.Application.Interfaces;

namespace TouristChallenge1.Controllers
{
    public class RouteController : Controller
    {
        public IRouteService _service { get; set; }

        public RouteController(IRouteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> FindBestRoute(FindRouteRequest request)
        {
            return Ok(await _service.FindBestRoute(request));
        }
    }
}