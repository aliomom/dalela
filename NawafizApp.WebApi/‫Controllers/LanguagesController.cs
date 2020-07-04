using NawafizApp.Common;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using NawafizApp.WebApi.ActionFilters;
using NawafizApp.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NawafizApp.WebApi.Controllers
{
    public class LanguagesController : ApiBaseController
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }


        /// <summary>
        /// Get language properties by code
        /// </summary>
        /// <param name="code">The code of the language ('ar' or 'en)</param>
        /// <returns>LanguageDto</returns>
        [HttpGet]
        [Route("~/api/Languages/{code}")]
        public LanguageDto Get(string code)
        {
            var model = _languageService.GetLanguageByCode(code);
            if (model != null)
                return model;
            throw new HttpResponseException(NotFoundMessage("لا يوجد لغة تتبع لهذا الكود"));
        }
     

        /// <summary>
        /// Add new language
        /// </summary>
        /// <param name="dto">new language dto</param>
        /// <returns>ID of the newly created language</returns>
      //  [Authorize(Roles="DeveloperRole,AdminRole")]
        [ValidateModelAttribute]
        [HttpPost]
        [Route("~/api/Languages/Add")]
       // [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int Add([FromBody]LanguageDto dto)
        {
            return _languageService.Add(dto);
        }
        
        [Authorize(Roles="DeveloperRole")]
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/Languages/Edit")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool Edit([FromBody]LanguageDto dto)
        {
            //var lang = _languageService.GetById(dto.Id);
            //if (lang != null)
            //{
            //    ModelState.AddModelError("code", "Code already taken!");
            //    throw new HttpResponseException(NotValidMessage(ModelState));
            //}
            return _languageService.Edit(dto);
        }

    }
}