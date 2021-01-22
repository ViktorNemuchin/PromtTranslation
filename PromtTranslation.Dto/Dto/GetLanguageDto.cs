using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PromtTranslation.Domain.Dto
{
    public class GetLanguageDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

    }
}
