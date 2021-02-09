using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Dto
{
    public class ResponseTranslationEntityDto
    {
        private Guid _translationId { get; set; }
        private string _status { get; set; }
        private string _local { get; set; }

        public ResponseTranslationEntityDto(Guid translationDto, string status, string local)
            => (_translationId, _status, _local) = (translationDto, status, local);

        public Guid TranslationId 
        {
            get => _translationId;
        }
        public string Status 
        {
            get => _status;
        }
        public string Local
        {
            get => _local;
        }

    }
}
