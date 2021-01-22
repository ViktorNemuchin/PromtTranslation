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
            //if(Enum.TryParse<LocaleEnum>(locale, out var result))
            //{
            //    switch (result) 
            //    {
            //        case LocaleEnum.ru:
            //            return await _translationContext.Translations.FirstOrDefaultAsync(x => x.RussianText == text);
            //        case LocaleEnum.en:
            //            return await _translationContext.Translations.FirstOrDefaultAsync(x => x.EnglishText == text);
            //        case LocaleEnum.fr:
            //            return await _translationContext.Translations.FirstOrDefaultAsync(x => x.FrenchText == text);
            //        case LocaleEnum.it:
            //            return await _translationContext.Translations.FirstOrDefaultAsync(x => x.ItalianText == text);
            //        case LocaleEnum.da:
            //            return await _translationContext.Translations.FirstOrDefaultAsync(x => x.Danish == text);
            //    }
            //}
            //return null;
        }

        
    }
}
