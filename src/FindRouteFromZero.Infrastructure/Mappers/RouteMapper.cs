using AutoMapper;
using FindRouteFromZero.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRouteFromZero.Infrastructure.Repositories.Routes
{
    public static class RouteMapper
    {
        public static IMapper mapper;

        static RouteMapper()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RouteCsv, Route>().ReverseMap();
            }).CreateMapper();
        }
        //public static Route Map(RouteCsv route)
        //{
        //    return mapper.Map<Route>(route);
        //}
        public static Route Map(this RouteCsv route)
        {
            return mapper.Map<Route>(route);
        }
        //public static RouteCsv Map(this Route route)
        //{
        //    return mapper.Map<RouteCsv>(route);
        //}
    }
}
