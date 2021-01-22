using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Models
{
    public class StatusModel:BaseModel
    {
        public string StatusValue { get; set; }
        public List<TranslationModel> Translations { get; set; }
    }
}
