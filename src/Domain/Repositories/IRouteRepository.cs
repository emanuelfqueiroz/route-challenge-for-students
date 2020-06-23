using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristChallenge1.Domain.Repositories
{
    public interface IRouteRepository
    {
        Task<List<Route>> GetAllAsync();
    }
}
