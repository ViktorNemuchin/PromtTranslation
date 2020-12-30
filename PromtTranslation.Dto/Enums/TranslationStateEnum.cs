using System;
using System.Collections.Generic;
using System.Text;

namespace PromtTranslation.Domain.Enums
{
    public enum TranslationStateEnum
    {
        AddedToTheSystem,
        IsTranslating,
        Translated,
        Error,
        Cancelled
    }
}
