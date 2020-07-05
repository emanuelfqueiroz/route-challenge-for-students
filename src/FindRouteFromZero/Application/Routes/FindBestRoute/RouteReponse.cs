using System.Collections.Generic;

namespace FindRouteFromZero.Application.Routes.FindBestRoute
{
    public class RouteReponse
    {
        public List<string> Routes { get; set; }
        public decimal TotalCost { get; set; }
    }
}
