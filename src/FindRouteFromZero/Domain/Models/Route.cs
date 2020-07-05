using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRouteFromZero.Domain.Models
{
    //Clean Classes - What do we should do?
    public class Route
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Cost { get; set; }
    }
}
