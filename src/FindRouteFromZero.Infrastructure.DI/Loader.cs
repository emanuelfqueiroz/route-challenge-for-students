using FindRouteFromZero.Application.Routes;
using FindRouteFromZero.Application.Routes.Finder;

using FindRouteFromZero.Domain.Repositories;
using FindRouteFromZero.Infrastructure.Repositories.Routes;
using Microsoft.Extensions.DependencyInjection;
using FindRouteFromZero.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRouteFromZero.Infrastructure.DI
{
    public  class Loader
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IRouteService, RouteService>();
            services.AddSingleton<IRouteRepository, CsvRouteRepository>();
            services.AddSingleton<IFinderShortestPath, DijkstraAdapter>();
        }
    }
}
