using CsvHelper;
using FindRouteFromZero.Domain.Models;
using FindRouteFromZero.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FindRouteFromZero.Infrastructure.Repositories.Routes
{
    public class CsvRouteRepository : IRouteRepository
    {
        IConfiguration _config;
        public string FilePath => _config["routes_path"];

        public CsvRouteRepository(IConfiguration config)
        {
            this._config = config;
        }

        public async Task<List<Route>> GetAllRoutes()
        {
            using (var reader = new StreamReader(FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                var records = csv.GetRecords<RouteCsv>();
                // version 01
                // return await Task.FromResult(records.ToList().Select(c => new Route()
                //{
                //    Cost = c.Cost,
                //    From = c.From,
                //    To = c.To
                //});

                // version 2
                //var routes = records.ToList().Select(c => {
                //    return RouteMapper.mapper.Map<RouteCsv, Route>(c);
                //}).ToList();

                // version 3
                //var routes = records.ToList().Select(c =>
                //{
                //    return RouteMapper.Map(c);

                //}).ToList();

                //version 4
                var routes = records.ToList().Select(c => c.Map()).ToList();
                return await Task.FromResult(routes);
            }
        }
    }
}
