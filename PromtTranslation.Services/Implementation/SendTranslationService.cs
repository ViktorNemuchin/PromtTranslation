using PromtTranslation.Domain.Dto;
using PromtTranslation.Domain.Models;
using PromtTranslation.Dtl.UnitOfWowrk.Interface;
using PromtTranslation.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PromtTranslation.Services.Implementation
{
    public class SendTranslationService : ISendTranslationService
    {
        private readonly ITranslatioonUnitOfWork _translatioonUnitOfWork;
        private readonly HttpClient _httpclient;


        public SendTranslationService(ITranslatioonUnitOfWork translationUnitOfWork, HttpClient httpClient, string bankOfIdeasUrl = "")
        {
            _translatioonUnitOfWork = translationUnitOfWork;
            _httpclient = httpClient;
            //_httpclient.BaseAddress = new Uri("http://localhost:56875/Health/Translation/Post");
            _httpclient.BaseAddress = new Uri(bankOfIdeasUrl);

        }
        public async Task SendTranslationEntries()
        {
            var statusId = await GetStatusIdByStatusName("Обрабатывается");
            var completedStatusId = await GetStatusIdByStatusName("Обравботан");
            var translations = await _translatioonUnitOfWork.Translations.GetTranslationEntriesForTranslation(statusId);
            foreach (var translation in translations)
            {
                if (await SendAllTranslationTexts(translation.Translations))
                    translation.StatusId = completedStatusId;
            }
            await _translatioonUnitOfWork.Commit();
        }
        private async Task<bool> SendAllTranslationTexts(List<TranslationTextModel> translations)
        {
            foreach (var translation in translations)
            {
                if (!await SendTranslation(new SendTranslationDto(translation.TranslationModelId, translation.Language, translation.Text), string.Empty))
                {
                    return false;
                }
            }
            return true;
        }
        private async Task<Guid> GetStatusIdByStatusName(string statusName)
        {
            var status = await _translatioonUnitOfWork.Status.GetStatusByValue(statusName);
            return status.Id;
        }
        private async Task<bool> SendTranslation(SendTranslationDto tranlatedText, string sendTranslationUrl)
        {

            var requestContent = new StringContent(JsonSerializer.Serialize<SendTranslationDto>(tranlatedText));
            requestContent.Headers.ContentType.MediaType = "application/json";
            var response = await _httpclient.PostAsync(sendTranslationUrl, requestContent);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
