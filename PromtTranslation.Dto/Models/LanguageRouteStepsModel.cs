using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Models
{
    public class LanguageRouteStepsModel:BaseModel
    {
        public string Language { get; set; }
        public string RouteSteps { get; set; }
    }
}
