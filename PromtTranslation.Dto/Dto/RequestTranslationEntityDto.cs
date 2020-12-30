using System;
using System.Collections.Generic;
using System.Text;


namespace PromtTranslation.Domain.Dto
{
    public class RequestTranslationEntityDto
    {
        private string _translationText { get; set; }
        private string _translationLocal { get; set; }
        private string _translationRouteName { get; set; }

        public RequestTranslationEntityDto(string translationText, string translationLocal)
            => (_translationText, _translationLocal, _translationRouteName) = (translationText, translationLocal, "default");
        public RequestTranslationEntityDto(string translationText, string translationLocal, string translationRouteName)
            => (_translationText, _translationLocal, _translationRouteName) = (translationText, translationLocal, translationRouteName);

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
        public string TranslationRouteName 
        {
            get => _translationRouteName;
        }
    }
}
