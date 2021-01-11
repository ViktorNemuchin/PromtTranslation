using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Models
{
    public class TranslationTextModel:BaseModel
    {
        public string Text { get; set; }
        public string Language { get; set; }
        public TranslationTextModel(string text, string language) =>
            (Text, Language) = (text, language);
    }
}
