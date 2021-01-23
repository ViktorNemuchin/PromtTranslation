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
        private readonly ILogger<PromtTranslationJob> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITranslationService _translationService;

        public PromtTranslationJob(ILogger<PromtTranslationJob> logger, IHttpClientFactory httpClientFactory, ITranslationService translationService) 
        {
            _httpClientFactory = httpClientFactory;
            _translationService = translationService;
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _translationService.TranslateText("Text");
            _logger.LogInformation("Hello world!");
            return Task.CompletedTask;
        }
    }
}
