using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristChallenge1.InfraStructure.Data
{
    public class RouteCsv
    {
      

        [Index(0)]
        public string Origin { get; set; }

        [Index(1)]
        public string Destination { get; set; }

        [Index(2)]
        public decimal Cost { get; set; }

    }

    public class RouteMap : ClassMap<RouteCsv>
    {
        public RouteMap()
        {
            Map(m => m.Origin).Index(0);
            Map(m => m.Destination).Index(1);
            Map(m => m.Cost).Default("0.0000").Index(2);
           
        }
    }
}
