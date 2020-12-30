using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Models
{
    public class TranslationModel
    {
        public Guid TranslationId { get; set; }
        public string RussianText { get; set; }
        public string EnglishText { get; set; }
        public string FrenchText { get; set; }
        public string ItalianText { get; set; }
        public string Danish { get; set; }
        public int Status { get; set; }



    }
}
