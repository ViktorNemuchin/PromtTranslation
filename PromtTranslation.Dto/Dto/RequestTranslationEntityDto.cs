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

        private Guid _statusId { get; set; }

        public RequestTranslationEntityDto(string translationText, string translationLocal, Guid statusId)
            => (_translationText, _translationLocal, _translationRouteName, _statusId) = (translationText, translationLocal, "default", statusId);
        public RequestTranslationEntityDto(string translationText, string translationLocal, string translationRouteName, Guid statusId)
            => (_translationText, _translationLocal, _translationRouteName, _statusId) = (translationText, translationLocal, translationRouteName, statusId);
        public RequestTranslationEntityDto(string translationText, Guid statusId) =>
            (_translationText, _statusId) = (translationText, statusId);
        public RequestTranslationEntityDto(string translationText) =>
            (_translationText) = (translationText);
        public RequestTranslationEntityDto() { }
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
        public Guid StatusId 
        {
            get => _statusId;
        }
    }
}
