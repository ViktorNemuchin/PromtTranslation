using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PromtTranslation.Domain.Dto
{
    public class RouteStepDto
    {
        [JsonPropertyName("text")]
        public string Text { get; private set; }
        [JsonPropertyName("from")]
        public string From { get; private set; }
        [JsonPropertyName("to")]
        public string To { get; private set; }
        [JsonPropertyName("profile")]
        public string Profile { get; private set; }

        public RouteStepDto(string text, string from, string to,string profile) =>
             (Text, From, To, Profile) = (text, from, to, profile);
    }
}
