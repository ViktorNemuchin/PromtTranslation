using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Dto
{
    public class RouteStepDto
    {
        public string Text { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }

        public RouteStepDto(string text, string from, string to) =>
             (Text, From, To) = (text, from, to);
    }
}
