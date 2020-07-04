using Microsoft.Owin.Security;
using NawafizApp.Common;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using NawafizApp.WebApi.ActionFilters;
using NawafizApp.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using NawafizApp.Common.Resources;
using PagedList;

namespace NawafizApp.WebApi.Controllers
{
    public class GuideFavoriteController : ApiAuthorizeBaseController
    {
        private readonly IGuideFavoriteService _GuideFavoriteService;

        public GuideFavoriteController(IGuideFavoriteService IGuideFavoriteService, ApplicationUserManager userManager):base(userManager)
        {
            _GuideFavoriteService = IGuideFavoriteService;
        }
        /// <summary>
        /// Add classify to your favorite
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Return Id in favorite table if added correctly</returns>
        [ValidateModelAttribute]
        [Authorize]
        [HttpPost]
        [Route("~/api/GuideFavoriteController/Add")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int Add(InputGuideFavoriteDto dto)
        {//LanguageHelper Language,
           if(!_GuideFavoriteService.IsClassifyIdExist_ForThisUser_InGuideFavorite(getCurrentUserGuid(), dto.ClassifyId))
            return _GuideFavoriteService.Add(dto, getCurrentUserGuid());

            throw new HttpResponseException(NotFoundMessage(FavoriteResource.Classify_is_added));

            // return _languageService.Add(dto);
        }
        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        //  [ValidateModelAttribute]
        [Authorize]
        [HttpPut]
        [Route("~/api/GuideFavoriteController/Edit")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool Edit(InputGuideFavoriteDto dto)
        {//LanguageHelper Language,

            return _GuideFavoriteService.Edit(dto, getCurrentUserGuid());
            // return _languageService.Add(dto);
        }

        /// <summary>
        /// Delete classify from your favorite
        /// </summary>
        /// <param name="ClassifyId"> Classify Id</param>
        /// <returns>return true if if deleted correctly , or return false</returns>
        [Authorize]
        [HttpDelete]
        [Route("~/api/GuideFavoriteController/Delete")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool Delete(int ClassifyId)
        {//LanguageHelper Language,

            return _GuideFavoriteService.Delete(ClassifyId, getCurrentUserGuid());
            // return _languageService.Add(dto);
        }
        /// <summary>
        /// Get User favorite
        /// </summary>
        /// <returns>GuideClassifySimplifyDto</returns>
        [Authorize]
        [HttpGet]
        [Route("~/api/GuideFavoriteController/GetFavorites")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public IPagedList<GuideClassifySimplifyDto> GetFavorites(int pageSize, int? page)
        {//LanguageHelper Language,
            var pageNumber = page ?? 1;
            var fav_res = _GuideFavoriteService.GetFavorites(CurrentLanguage, getCurrentUserGuid());
            if (fav_res.Any())
            {
                var x = fav_res.ToPagedList(pageNumber, pageSize);
                return x;
                
            }
            
            throw new HttpResponseException(NotFoundMessage(FavoriteResource.Classifies_Not_Exist));
            // return _languageService.Add(dto);
        }



    }
}