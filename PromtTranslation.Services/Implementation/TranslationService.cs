using System;
using System.Collections.Generic;
using System.Text;
using PromtTranslation.Services.Interface;
using PromtTranslation.Domain.Dto;
using PromtTranslation.Domain.Models;
using PromtTranslation.Dtl.UnitOfWowrk.Interface;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PromtTranslation.Services.Implementation
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslatioonUnitOfWork _translatioonUnitOfWork;
        private readonly HttpClient _httpclient;
        private readonly ILogger<TranslationService> _logger;


        public TranslationService(ITranslatioonUnitOfWork translationUnitOfWork, HttpClient httpClient, ILoggerFactory logger)
        {
            _translatioonUnitOfWork = translationUnitOfWork;
            _httpclient = httpClient;
            _httpclient.BaseAddress = new Uri("http://localhost/AS//Services/v1/rest.svc/");
            _logger = logger.CreateLogger<TranslationService>();

        }


        public async Task TranslateAddedTranslationEntries() 
        {
            var statusId = await GetStatusIdByStatusName("Добавлен");
            var completedStatusId = await GetStatusIdByStatusName("Обрабатывается");
            var translations = await _translatioonUnitOfWork.Translations.GetTranslationEntriesForTranslation(statusId);
            foreach (var translation in translations) 
            {
                translation.Translations.AddRange(await TranslateTextForAllLanguages(translation, translation.Route.RouteName));
                translation.StatusId = completedStatusId;
            }
            await _translatioonUnitOfWork.Commit();
        }
        public async Task SendTranslationEntries()
        {
            var statusId = await GetStatusIdByStatusName("Переведен");
            var completedStatusId = await GetStatusIdByStatusName("Отправлен");
            var translations = await _translatioonUnitOfWork.Translations.GetTranslationEntriesForTranslation(statusId);
            foreach (var translation in translations)
            {
                translation.Translations.AddRange(await TranslateTextForAllLanguages(translation, translation.Route.RouteName));
                if(await SendAllTranslationTexts(translation.Translations))
                    translation.StatusId = completedStatusId;
            }
            await _translatioonUnitOfWork.Commit();
        }

        private async Task<bool> SendAllTranslationTexts(List<TranslationTextModel> translations) 
        {
            foreach (var translation in translations) 
            {
                if (!await SendTranslation(new SendTranslationDto(translation.TranslationModelId, translation.Language, translation.Text), "")) 
                {
                    return false;
                }
            }
            return true;
        }
        private async Task<List<TranslationTextModel>>TranslateTextForAllLanguages(TranslationModel translation, string routeName) 
        {
            var translationTextModelList = new List<TranslationTextModel>();
            foreach(var routeStep in translation.Route.LanguageRouteSteps) 
            {
                var textToTranslate = translation.Translations.Where(x => x.Language.Equals(routeStep.LanguageFrom)).FirstOrDefault();
                if(textToTranslate is null)
                    break;
                var translationResult = await TranslateRouteStep(routeStep, textToTranslate.Text);
                translationTextModelList.Add(translationResult);
            }
            return translationTextModelList;
        }

        private async Task<TranslationTextModel> TranslateRouteStep(LanguageRouteStepsModel step, string text) 
        {
            var translitionDto = new RouteStepDto(text, step.LanguageFrom, step.LanguageTo,"Универсальный");
            var translatedText = await GetTranslationFromPromt(translitionDto,"TranslateText");
            return new TranslationTextModel(translatedText, step.LanguageTo);
        }
        private async Task<string> GetTranslationFromPromt(RouteStepDto textToTranslate, string translateUrl)
        {

            var requestContent = new StringContent(JsonSerializer.Serialize<RouteStepDto>(textToTranslate));
            requestContent.Headers.ContentType.MediaType = "application/json";

            var response = await _httpclient.PostAsync(translateUrl, requestContent);
            _logger.LogInformation($"Тело запроса: {response.RequestMessage}");
            _logger.LogInformation($"Статус ответа: {response.StatusCode}, {response.ReasonPhrase}, {await response.Content.ReadAsStringAsync()}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            return null;
        }

        private async Task<bool> SendTranslation(SendTranslationDto tranlatedText,string sendTranslationUrl )
        {
            var requestContent = new StringContent(JsonSerializer.Serialize<SendTranslationDto>(tranlatedText));
            var response = await _httpclient.PostAsync(sendTranslationUrl, requestContent);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<ResponseTranslationEntityDto> TranslateText(RequestTranslationEntityDto requestTranslationEntity)
        {
            var rawLanguage = await GetLanguage(requestTranslationEntity.TranslationText, "DetectTextLanguage");
            if (string.IsNullOrEmpty(rawLanguage))
                return null;
            var language = rawLanguage.Replace("\\", "").Replace('"', ' ').Trim();
            
    

            var translationRoute = await GetTranslationRoute(language);
            
            var translationList = new List<TranslationTextModel>() { new TranslationTextModel(requestTranslationEntity.TranslationText, language) };
            var translationEntity = new TranslationModel(translationList);
            translationEntity.StatusId = await GetStatusIdByStatusName("Добавлен");
            translationEntity.RouteModelId = translationRoute.Id; 
            
            await _translatioonUnitOfWork.Translations.AddEntity(translationEntity);
            await _translatioonUnitOfWork.Commit();
            return new ResponseTranslationEntityDto(translationEntity.Id, translationEntity.Status.StatusValue, language);
        }

        private async Task<Guid> GetStatusIdByStatusName(string statusName) 
        {
            var status = await _translatioonUnitOfWork.Status.GetStatusByValue(statusName);
            return status.Id;
        }
        private async Task<string> GetLanguage(string textToTranslate, string getLanguageUrl) 
        {
            var requestObject = new GetLanguageDto() { Text = textToTranslate };
            //_httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
            var requestContent = new StringContent(JsonSerializer.Serialize<GetLanguageDto>(requestObject));
            requestContent.Headers.ContentType.MediaType = "application/json";
            var response = await _httpclient.PostAsync(getLanguageUrl, requestContent);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            return null;
        }
 
        private async Task<RouteModel> GetTranslationRoute(string routeName) =>
            await _translatioonUnitOfWork.Routes.GetRouteByName(routeName);

    } 
}
