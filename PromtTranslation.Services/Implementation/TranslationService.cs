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

namespace PromtTranslation.Services.Implementation
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslatioonUnitOfWork _translatioonUnitOfWork;
        private readonly HttpClient _httpclient;
        private readonly string _getLanguageUrl;

        public TranslationService(ITranslatioonUnitOfWork translationUnitOfWork, HttpClient httpClient) =>
            (_translatioonUnitOfWork, _httpclient, _getLanguageUrl) = (translationUnitOfWork, httpClient, "");
             
        public async Task<ResponseTranslationEntityDto> TranslateText(RequestTranslationEntityDto requestTranslationEntity)
        {
            var language = await GetLanguage(requestTranslationEntity.TranslationText);
            
            if (string.IsNullOrEmpty(language))
                throw new ArgumentNullException("Не могу определить язык");
            
            var translationRoute = await GetTranslationRoute(requestTranslationEntity.TranslationRouteName);
            var translationList = new List<TranslationTextModel>() { new TranslationTextModel(requestTranslationEntity.TranslationText, language) };
            var translationEntity = new TranslationModel(translationList);
            
            translationEntity.StatusId = requestTranslationEntity.StatusId;
            translationEntity.RouteModelId = translationRoute.Id; 
            
            await _translatioonUnitOfWork.Translations.AddEntity(translationEntity);
            await _translatioonUnitOfWork.Commit();
            return new ResponseTranslationEntityDto(translationEntity.Id, translationEntity.Status.StatusValue);
        }
        private async Task<string> GetLanguage(string textToTranslate) 
        {
            var requestObject = new GetLanguageDto() { Text = textToTranslate };
            var requestContent = new StringContent(JsonSerializer.Serialize<GetLanguageDto>(requestObject));
            var response = await _httpclient.PostAsync(_getLanguageUrl, requestContent);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            return null;
        }

        private async Task<StatusModel> GetDefaultStatus(Guid defaultStatusId) => 
            await _translatioonUnitOfWork.Status.GetEntity(defaultStatusId);
        private async Task<RouteModel> GetTranslationRoute(string routeName) =>
            await _translatioonUnitOfWork.Routes.GetRouteByName(routeName);

    } 
}
