using Microsoft.Owin.Security;
using NawafizApp.Common;
using NawafizApp.Common.Resources;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using NawafizApp.WebApi.ActionFilters;
using NawafizApp.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace NawafizApp.WebApi.Controllers
{
    public class AdminGuideCity_TownController : ApiAuthorizeBaseController
    {
        private readonly IGuideCityService _iGuideCityService;

        private readonly IGuideTownService _iGuideTownService;
        
        public AdminGuideCity_TownController(IGuideCityService IGuideCityService, IGuideTownService IGuideTownService, ApplicationUserManager userManager):base(userManager)
        {
            _iGuideCityService = IGuideCityService;
            _iGuideTownService = IGuideTownService;
        }

        #region City


        /// <summary>
        /// Add City 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Id of city in database</returns>
        [ValidateModelAttribute]
        [HttpPost]
        [Route("~/api/AdminGuideCity_Town/AddCity")]
        // [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int AddCity([FromBody]InputGuideCityDto dto)
        {
            return _iGuideCityService.Add(CurrentLanguage, dto);
        }
        /// <summary>
        /// Edit city
        /// </summary>
        /// <param name="dto"></param>
        /// <returns> return true if if updated correctly , and false if not</returns>
        // [Authorize(Roles = "DeveloperRole")]
        // [ValidateModelAttribute]
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/AdminGuideCity_Town/EditCity")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool EditCity([FromBody]InputGuideCityDto dto)
        {
           
            return _iGuideCityService.Edit(CurrentLanguage, dto);
        }

        /// <summary>
        /// Delete city by city Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> return true if If deleted correctly , and false if not</returns>
        [HttpDelete]
        [Route("~/api/AdminGuideCity_Town/DeleteCity")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool DeleteCity(int id)
        {
            var x = _iGuideCityService.Delete(id);
            if (x!=null)
            return (bool)x;
            throw new HttpResponseException(NotFoundMessage(CityAndTown.Id_failed));
        }

        #endregion

        #region Town

        /// <summary>
        /// Add town 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Id of town in database</returns>
        [ValidateModelAttribute]
        [HttpPost]
        [Route("~/api/AdminGuideCity_TownController/AddTown")]
        // [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int AddTown([FromBody]InputGuideTownDto dto)
        {
            var t = _iGuideTownService.Add(CurrentLanguage, dto);
            if(t!=null)
              return (int)t;
            else
                throw new HttpResponseException(NotFoundMessage(CityAndTown.TownNameNotExist));

        }
        /// <summary>
        /// Edit town
        /// </summary>
        /// <param name="dto"></param>
        /// <returns> return true if if updated correctly , and false if not</returns>
        // [Authorize(Roles = "DeveloperRole")]
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/AdminGuideCity_TownController/EditTown")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool EditTown([FromBody]InputGuideTownDto dto)
        {
            var t= _iGuideTownService.Edit(CurrentLanguage, dto);

            if (t != null)
                return (bool)t;
            else
                throw new HttpResponseException(NotFoundMessage(CityAndTown.TownNameNotExist));
        }

        /// <summary>
        /// Delete town by town Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> return true if If deleted correctly , and false if not</returns>
        [HttpDelete]
        [Route("~/api/AdminGuideCity_TownController/DeleteTown")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool DeleteTown(int id)
        {
            var x = _iGuideTownService.Delete(id);
            if (x != null)
                return (bool)x;
            throw new HttpResponseException(NotFoundMessage(CityAndTown.Id_failed));
        }


        #endregion

        #region GetCity

        /// <summary>
        /// Get All cities 
        /// </summary>
        /// <returns>GuideCityDto</returns>

        [HttpGet]
        [Route("~/api/AdminGuideCity_TownController/GetAllCities")]
        public List<GuideCityDto> GetAllCities()
        {
            var model = _iGuideCityService.GetAllGuideCities(CurrentLanguage);
            if (model.Any())
            { return model; }
            throw new HttpResponseException(NotFoundMessage(CityAndTown.CityNotExist));

        }
        /// <summary>
        /// Get city by city Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>GuideCityDto</returns>
        [HttpGet]
        [Route("~/api/AdminGuideCity_TownController/GetCityById")]
        public GuideCityDto GetCityById(int id)
        {
            var model = _iGuideCityService.GetGuideCityById(CurrentLanguage, id);
            if (model != null)
                return model;
            throw new HttpResponseException(NotFoundMessage(CityAndTown.CityNotExist));

        }

        #endregion

    }
}