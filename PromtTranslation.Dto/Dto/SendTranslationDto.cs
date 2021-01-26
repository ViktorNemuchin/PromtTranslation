using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Dto
{
    public class SendTranslationDto
    {
        public Guid TranslationId { get; private set; }
        public string Local { get; private set; }
        public string TranslationText { get; private set; }
        public SendTranslationDto(Guid translationId, string local, string tranlationText)
            => (TranslationId, Local, TranslationText) = (translationId, local, tranlationText);
    }
}
