using Microsoft.EntityFrameworkCore;
using PromtTranslation.Domain.Models;
using PromtTranslation.Dtl.Context;
using PromtTranslation.Dtl.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromtTranslation.Dtl.Repositories.Implementation
{
    public class RouteRepository: BaseRepository<RouteModel>, IRouteRepository
    {
        private readonly TranslationDbContext _translationContext;
        public RouteRepository(TranslationDbContext translationContext)
            : base(translationContext) { _translationContext = translationContext; }

        public async Task<RouteModel> GetRouteByName(string routeValue) =>
           await _translationContext.Routes
            .FirstOrDefaultAsync(x => x.RouteName == routeValue);
    }
}
