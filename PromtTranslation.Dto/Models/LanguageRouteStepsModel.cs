using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Models
{
    public class LanguageRouteStepsModel:BaseModel
    {
        public string LanguageFrom { get; set; }
        public string LanguageTo { get; set; }
        public RouteModel Route { get; set; }
        public Guid RouteId { get; set; }
    }
}
