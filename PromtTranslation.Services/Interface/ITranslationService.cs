using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PromtTranslation.Domain.Dto;

namespace PromtTranslation.Services.Interface
{
    public interface ITranslationService
    {
        Task<ResponseTranslationEntityDto> TranslateText(RequestTranslationEntityDto requestTranslationEntity);

    }
}
