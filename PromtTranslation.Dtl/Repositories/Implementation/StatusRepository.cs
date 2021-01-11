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
    public class StatusRepository:BaseRepository<StatusModel>, IStatusRepository
    {
        private readonly TranslationDbContext _translationContext;
        public StatusRepository(TranslationDbContext translationContext)
            :base(translationContext) { _translationContext = translationContext; }

        public async Task<StatusModel> GetStatusByValue(string statusValue) =>
            await _translationContext.Statuses.FirstOrDefaultAsync(x => x.StatusValue == statusValue);
    }
}
