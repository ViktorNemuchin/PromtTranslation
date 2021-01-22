using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Dto
{
    public class ResponseTranslationEntityDto
    {
        private Guid _translationId { get; set; }
        private string _status { get; set; }

        public ResponseTranslationEntityDto(Guid translationDto, string status)
            => (_translationId, _status) = (translationDto, status);

        public Guid TranslationId 
        {
            get => _translationId;
        }
        public string Status 
        {
            get => _status;
        }

    }
}
