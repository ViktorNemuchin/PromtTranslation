using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Models
{
    public class RouteModel : BaseModel
    {
        public string RouteName { get; set; }
        public List<LanguageRouteStepsModel> LanguageRouteSteps{ get; set; }
        public List<TranslationModel> Translations {get; set;}
    }
}
