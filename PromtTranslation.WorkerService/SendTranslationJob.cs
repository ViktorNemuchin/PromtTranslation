using Microsoft.Extensions.Logging;
using PromtTranslation.Services.Interface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace PromtTranslation.WorkerService
{
    public class SendTranslationJob : IJob
    {

        private readonly ILogger<SendTranslationJob> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISendTranslationService _sendTranslationService;

        public SendTranslationJob(ILogger<SendTranslationJob> logger, IHttpClientFactory httpClientFactory, ISendTranslationService sendTranslationService)
        {
            _httpClientFactory = httpClientFactory;
            _sendTranslationService = sendTranslationService;
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            Task.WaitAll(_sendTranslationService.SendTranslationEntries());
            return Task.CompletedTask;
        }
    }
}
