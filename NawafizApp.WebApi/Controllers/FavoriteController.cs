using Microsoft.Owin.Security;
using NawafizApp.Common;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using NawafizApp.WebApi.ActionFilters;
using NawafizApp.WebApi.Attributes;
using System;
using PagedList;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using NawafizApp.Common.Resources;

namespace NawafizApp.WebApi.Controllers
{
    public class FavoriteController : ApiAuthorizeBaseController
    {
        private readonly IFavoriteService _FavoriteService;

        public FavoriteController(IFavoriteService IFavoriteService, ApplicationUserManager userManager):base(userManager)
        {
            _FavoriteService = IFavoriteService;
        }

        //  [Authorize(Roles = "DeveloperRole,AdminRole")]
        /// <summary>
        /// Add classify to your favorite
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Return Id in favorite table if added correctly</returns>
        [ValidateModelAttribute]
        [Authorize]
        [HttpPost]
        [Route("~/api/Favorite/Add")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int Add(InputFavoriteDto dto)
        {//LanguageHelper Language,
           if(! _FavoriteService.IsClassifyIdExist_ForThisUser_InFavorite(getCurrentUserGuid(), dto.ClassifyId))
            return _FavoriteService.Add(dto, getCurrentUserGuid());

            throw new HttpResponseException(NotFoundMessage(FavoriteResource.Classify_is_added));

            // return _languageService.Add(dto);
        }

      //  [ValidateModelAttribute]
      /// <summary>
      /// Not used
      /// </summary>
      /// <param name="dto"></param>
      /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("~/api/Favorite/Edit")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool Edit(InputFavoriteDto dto)
        {//LanguageHelper Language,

            return _FavoriteService.Edit(dto, getCurrentUserGuid());
            // return _languageService.Add(dto);
        }
        /// <summary>
        /// Delete classify from your favorite
        /// </summary>
        /// <param name="ClassifyId"> Classify Id</param>
        /// <returns>return true if if deleted correctly , or return false</returns>
        [Authorize]
        [HttpDelete]
        [Route("~/api/Favorite/Delete")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool Delete(int ClassifyId)
        {//LanguageHelper Language,

            return _FavoriteService.Delete(ClassifyId, getCurrentUserGuid());
            // return _languageService.Add(dto);
        }
        /// <summary>
        /// Get User favorite
        /// </summary>
        /// <returns>ClassifySimplifyDto</returns>
        [Authorize]
        [HttpGet]
        [Route("~/api/Favorite/GetFavorites")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public IPagedList<ClassifySimplifyDto> GetFavorites(int pageSize, int? page)
        {//LanguageHelper Language,
            var pageNumber =page ?? 1;
            var fav_res = _FavoriteService.GetFavorites(CurrentLanguage, getCurrentUserGuid());
            if (fav_res.Any())
            {
                
                var x = fav_res.ToPagedList(pageNumber, pageSize);
                return x;
               // return fav_res;
            }
            throw new HttpResponseException(NotFoundMessage(FavoriteResource.Classifies_Not_Exist));
            // return _languageService.Add(dto);
        }



    }
}