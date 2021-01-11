using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PromtTranslation.Domain.Models;

namespace PromtTranslation.Dtl.Repositories.Interface
{
    public interface IRouteRepository:IBaseRepository<RouteModel>
    {
        Task<RouteModel> GetRouteByName(string statusValue);
    }
}
