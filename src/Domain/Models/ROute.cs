using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristChallenge1.Domain.Models
{
    public class ROute
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Cost { get; set; }
    }
}
