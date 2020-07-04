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
    public class AdminCity_TownController : ApiAuthorizeBaseController
    {
        private readonly ICityService _iCityService;

        private readonly ITownService _iTownService;
        private readonly IGuideNeighborhoodService _iGuideNeighborhoodService;

        public AdminCity_TownController(ICityService ICityService, ITownService ITownService, IGuideNeighborhoodService IGuideNeighborhoodService, ApplicationUserManager userManager):base(userManager)
        {
            _iCityService = ICityService;
            _iTownService = ITownService;
            _iGuideNeighborhoodService = IGuideNeighborhoodService;
        }

        #region City

        [ValidateModelAttribute]
        [HttpPost]
        [Route("~/api/AdminCity_Town/AddCity")]
        // [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int AddCity([FromBody]InputCityDto dto)
        {
            return _iCityService.Add(CurrentLanguage, dto);
        }

        // [Authorize(Roles = "DeveloperRole")]
        // [ValidateModelAttribute]
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/AdminCity_Town/EditCity")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool EditCity([FromBody]InputCityDto dto)
        {
           
            return _iCityService.Edit(CurrentLanguage, dto);
        }

        [HttpDelete]
        [Route("~/api/AdminCity_Town/DeleteCity")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool DeleteCity(int id)
        {
            var x = _iCityService.Delete(id);
            if (x!=null)
            return (bool)x;
            throw new HttpResponseException(NotFoundMessage(CityAndTown.Id_failed));
        }

        #endregion

        #region Town

        [ValidateModelAttribute]
        [HttpPost]
        [Route("~/api/AdminCity_TownController/AddTown")]
        // [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int AddTown([FromBody]InputTownDto dto)
        {
            var t = _iTownService.Add(CurrentLanguage, dto);
            if(t!=null)
              return (int)t;
            else
                throw new HttpResponseException(NotFoundMessage(CityAndTown.TownNameNotExist));

        }

        // [Authorize(Roles = "DeveloperRole")]
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/AdminCity_TownController/EditTown")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool EditTown([FromBody]InputTownDto dto)
        {
            var t= _iTownService.Edit(CurrentLanguage, dto);

            if (t != null)
                return (bool)t;
            else
                throw new HttpResponseException(NotFoundMessage(CityAndTown.TownNameNotExist));
        }

        [HttpDelete]
        [Route("~/api/AdminCity_TownController/DeleteTown")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool DeleteTown(int id)
        {
            var x = _iTownService.Delete(id);
            if (x != null)
                return (bool)x;
            throw new HttpResponseException(NotFoundMessage(CityAndTown.Id_failed));
        }


        #endregion

    

    }
}