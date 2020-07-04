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
    public class CityController: ApiBaseController
    {
        private readonly ICityService _lCityService;

        public CityController(ICityService lCityService)
        {
            _lCityService = lCityService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>CityDto</returns>

        [HttpGet]
        [Route("~/api/City/GetAllCities")]
        public List<CityDto> GetAllCities()
        {
            var model= _lCityService.GetAllCities(CurrentLanguage);
            if (model.Any())
            { return model; }
            throw new HttpResponseException(NotFoundMessage(CityAndTown.CityNotExist));
            
        }

        [HttpGet]
        [Route("~/api/City/GetCityById")]
        public CityDto GetCityById(int id)
        {
            var model= _lCityService.GetCityById(CurrentLanguage,id);
            if (model != null)
                return model;
             throw new HttpResponseException(NotFoundMessage(CityAndTown.CityNotExist));
            
        }

       
    }
}
