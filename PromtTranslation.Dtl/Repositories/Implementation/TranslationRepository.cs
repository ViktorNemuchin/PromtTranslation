using PromtTranslation.Domain.Models;
using PromtTranslation.Dtl.Context;
using PromtTranslation.Dtl.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromtTranslation.Dtl.Repositories.Implementation
{
    public class TranslationRepository:BaseRepository<TranslationModel>, ITranslationRepository
    {
        private readonly TranslationDbContext _translationContext;
        public TranslationRepository(TranslationDbContext translationContext)
            : base(translationContext) { _translationContext = translationContext; }

        public Task<TranslationModel> GetTranlationByText(string text, string locale)
        {
            throw new NotImplementedException();
        }
    }
}
