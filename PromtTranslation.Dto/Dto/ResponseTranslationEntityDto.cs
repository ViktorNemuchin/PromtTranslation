using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Dto
{
    public class ResponseTranslationEntityDto
    {
        private Guid _translationId { get; set; }

        public ResponseTranslationEntityDto(Guid translationDto)
            => (_translationId) = (translationDto);

        public Guid TranslationId 
        {
            get => _translationId;
        }

    }
}
