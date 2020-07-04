using NawafizApp.Common;
using NawafizApp.Common.Resources;
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
    public class GuideCityController : ApiBaseController
    {
        private readonly IGuideCityService _lGuideCityService;

        public GuideCityController(IGuideCityService lGuideCityService)
        {
            _lGuideCityService = lGuideCityService;
        }


        /// <summary>
        /// Get All cities 
        /// </summary>
        /// <returns>GuideCityDto</returns>

        [HttpGet]
        [Route("~/api/GuideCity/GetAllCities")]
        public List<GuideCityDto> GetAllCities()
        {
            var model= _lGuideCityService.GetAllGuideCities(CurrentLanguage);
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
        [Route("~/api/GuideCity/GetCityById")]
        public GuideCityDto GetCityById(int id)
        {
            var model= _lGuideCityService.GetGuideCityById(CurrentLanguage,id);
            if (model != null)
                return model;
             throw new HttpResponseException(NotFoundMessage(CityAndTown.CityNotExist));
            
        }

       
    }
}
