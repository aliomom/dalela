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
    public class AdminNeighborhoodController : ApiAuthorizeBaseController
    {
       
        private readonly IGuideNeighborhoodService _iGuideNeighborhoodService;

        public AdminNeighborhoodController(IGuideNeighborhoodService IGuideNeighborhoodService, ApplicationUserManager userManager):base(userManager)
        {
            _iGuideNeighborhoodService = IGuideNeighborhoodService;
        }



        #region Neighborhood
        /// <summary>
        /// Add Neighborhood
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ValidateModelAttribute]
        [HttpPost]
        [Route("~/api/AdminNeighborhood/AddNeighborhood")]
        // [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int AddNeighborhood([FromBody]InputGuideNeighborhoodDto dto)
        {
            var t = _iGuideNeighborhoodService.Add(CurrentLanguage, dto);
            if (t != null)
                return (int)t;
            else
                throw new HttpResponseException(NotFoundMessage(CityAndTown.Add_Neighborhood_Failed));

        }

        // [Authorize(Roles = "DeveloperRole")]
        /// <summary>
        /// Edit Neighborhood
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/AdminNeighborhood/EditNeighborhood")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool EditNeighborhood([FromBody]InputGuideNeighborhoodDto dto)
        {
            var t = _iGuideNeighborhoodService.Edit(CurrentLanguage, dto);

            if (t != null)
                return (bool)t;
            else
                throw new HttpResponseException(NotFoundMessage(CityAndTown.Edit_Neighborhood_Failed));
        }
        /// <summary>
        /// Delete Neighborhood
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/AdminNeighborhood/DeleteNeighborhood")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool DeleteNeighborhood(int id)
        {
            var x = _iGuideNeighborhoodService.Delete(id);
            if (x != null)
                return (bool)x;
            throw new HttpResponseException(NotFoundMessage(CityAndTown.Id_failed));
        }


        #endregion

    }
}