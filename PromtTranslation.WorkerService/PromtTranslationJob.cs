using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PromtTranslation.Services.Interface;
using Quartz;

namespace PromtTranslation.WorkerService
{
    public class PromtTranslationJob : IJob
    {
        private readonly ILoggerFactory _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITranslationService _translationService;

        public PromtTranslationJob(ILoggerFactory logger, IHttpClientFactory httpClientFactory, ITranslationService translationService) 
        {
            _httpClientFactory = httpClientFactory;
            _translationService = translationService;
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            Task.WaitAll(_translationService.TranslateAddedTranslationEntries());
            return Task.CompletedTask;
        }
    }
}
