using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristChallenge1.Domain.Models
{
    public class Route
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public decimal Cost { get; private set; }

        public Route(string from, string to, decimal cost)
        {
            this.From = from;
            this.To = to;
            this.Cost = cost;
        }
    }
}
