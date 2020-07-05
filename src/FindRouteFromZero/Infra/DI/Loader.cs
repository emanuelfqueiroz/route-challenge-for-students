using FindRouteFromZero.Application.Routes;
using FindRouteFromZero.Application.Routes.Finder;
using FindRouteFromZero.Application.Services;
using FindRouteFromZero.Domain.Repositories;
using FindRouteFromZero.Infra.Repositories.Routes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRouteFromZero.Infra.DI
{
    public static class Loader
    {
        internal static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IRouteService, RouteService>();
            services.AddSingleton<IRouteRepository, CsvRouteRepository>();
            services.AddSingleton<IFinderShortestPath, DijkstraAdapter>();
        }
    }
}
