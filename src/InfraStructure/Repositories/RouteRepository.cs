using Microsoft.AspNetDomain.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristChallenge1.Domain.Models;
using TouristChallenge1.Domain.Repositories;

namespace TouristChallenge1.InfraStructure.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        public async Task<List<Route>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
