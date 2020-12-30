using PromtTranslation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromtTranslation.Dtl.Repositories.Interface
{
    public interface ITranslationRepository: IBaseRepository<TranslationModel>
    {
        Task<TranslationModel> GetTranlationByText(string text, string locale);
    }
}
