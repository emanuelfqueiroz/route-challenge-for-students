using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristChallenge1.Application.Dtos
{
    public class FindRouteRequest
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}
