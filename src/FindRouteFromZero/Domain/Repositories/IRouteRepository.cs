using FindRouteFromZero.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRouteFromZero.Domain.Repositories
{
    public interface IRouteRepository
    {

        Task<List<Route>> GetAllRoutes();
    }
}
