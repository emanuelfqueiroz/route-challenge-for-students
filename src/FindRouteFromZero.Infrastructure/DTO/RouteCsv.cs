using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRouteFromZero.Infrastructure.Repositories.Routes
{
    /// <summary>
    /// (Infra) DTO  Data Transfer Object 
    /// </summary>
    public class RouteCsv
    {
        [Index(0)]
        public string From { get; set; }
        [Index(1)]
        public string To { get; set; }
        [Index(2)]
        public decimal Cost { get; set; }
    }
}
