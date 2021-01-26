using PromtTranslation.Domain.Models;
using PromtTranslation.Dtl.Context;
using PromtTranslation.Dtl.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PromtTranslation.Domain.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PromtTranslation.Dtl.Repositories.Implementation
{
    public class TranslationRepository:BaseRepository<TranslationModel>, ITranslationRepository
    {
        private readonly TranslationDbContext _translationContext;
        public TranslationRepository(TranslationDbContext translationContext)
            : base(translationContext) { _translationContext = translationContext; }

        public async Task<TranslationTextModel> GetTranslationByText(string text, string locale) 
        {
            return await _translationContext.TransaltionTexts.FirstOrDefaultAsync(x => x.Text == text || x.Language == locale);
        }
        public async Task<IEnumerable<TranslationModel>> GetTranslationEntriesForTranslation(Guid statusId) 
            => await _translationContext.Translations.Include(x => x.Route).ThenInclude(x => x.LanguageRouteSteps).Include(x => x.Translations).Where(y => y.StatusId == statusId).ToListAsync();

        
    }
}
