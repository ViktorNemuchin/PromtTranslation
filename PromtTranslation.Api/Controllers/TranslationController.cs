using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromtTranslation.Dtl.Context;
using PromtTranslation.Dtl.UnitOfWowrk.Interface;
using PromtTranslation.Services.Interface;
using PromtTranslation.Domain.Dto;

namespace PromtTranslation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        private readonly TranslationDbContext _translationDbContext;
        private readonly ITranslatioonUnitOfWork _translatioonUnitOfWork;
        private readonly ITranslationService _translationService;
        /// <summary>
        /// Конструктор контролера перевода текста
        /// </summary>
        /// <param name="translationDbContext"></param>
        /// <param name="translatioonUnitOfWork"></param>
        /// <param name="translationService"></param>
        public TranslationController(TranslationDbContext translationDbContext, ITranslatioonUnitOfWork translatioonUnitOfWork, ITranslationService translationService)
        {
            _translationDbContext = translationDbContext;
            _translatioonUnitOfWork = translatioonUnitOfWork;
            _translationService = translationService;
        }
        /// <summary>
        /// Перевод 
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        ///  
        ///  Post /Translation 
        ///  {
        ///      "translationText": "Test",
        ///      "translationLocal": "en"
        ///  }
        ///  
        /// </remarks>
        /// <param name="requestTranslationEntityDto">Сущность </param>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>   
        [HttpPost]
        public async Task<IActionResult> TranslateText(RequestTranslationEntityDto requestTranslationEntityDto)
        {
            //var response = await _mintosClientService.AbstractClient();
            //if (response == null)
            //    return NotFound("Check Db connection");
            return Ok(await _translationService.TranslateText(requestTranslationEntityDto));
        }
    }
}
