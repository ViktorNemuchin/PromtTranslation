using System;
using System.Collections.Generic;
using System.Text;
using PromtTranslation.Domain.Enums;

namespace PromtTranslation.Domain.Dto
{
    public class RequestTranslationEntityDto
    {
        private string _translationText { get; set; }
        private string _translationLocal { get; set; }
        private TranslationRouteEnum _translationRoute { get; set; }

        public RequestTranslationEntityDto(string translationText, string translationLocal)
            => (_translationText, _translationLocal, _translationRoute) = (translationText, translationLocal, TranslationRouteEnum.DefualtRoute);

        public string TranslationText 
        {
            get => _translationText;
            set => _translationText = value;
        }
        public string TranslationLocal
        {
            get => _translationLocal;
            set => _translationLocal = value;
        }
        public TranslationRouteEnum TranslationRoute 
        {
            get => _translationRoute;
        }
    }
}
