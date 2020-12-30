using PromtTranslation.Domain.Models;
using PromtTranslation.Dtl.Context;
using PromtTranslation.Dtl.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Dtl.Repositories.Implementation
{
    public class StatusRepository:BaseRepository<StatusModel>, IStatusRepository
    {
        private readonly TranslationDbContext _translationContext;
        public StatusRepository(TranslationDbContext translationContext)
            :base(translationContext) { _translationContext = translationContext; }
    }
}
