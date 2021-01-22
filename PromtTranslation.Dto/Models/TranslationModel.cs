using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Models
{
    public class TranslationModel : BaseModel
    {
        public Guid StatusId { get; set; }
        public StatusModel Status  {get; set;}
        public Guid RouteModelId { get; set; }
        public RouteModel Route {get;set;}
        public List<TranslationTextModel> Translations { get; set; }
        public TranslationModel (List<TranslationTextModel>transaltions) =>
            (Translations) = (transaltions);
        public TranslationModel() { }
    }
}
