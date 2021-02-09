using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromtTranslation.Services.Interface
{
    public interface ISendTranslationService
    {
        Task SendTranslationEntries();
    }
}
