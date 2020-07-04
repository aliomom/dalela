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
using System.Web;
using System.Web.Http;
using NawafizApp.Services.Dtos.Validators;
using NawafizApp.Common.Resources;

namespace NawafizApp.WebApi.Controllers
{
    public class GuideController : ApiBaseController
    {


        private readonly IGuideService _GuideService;

        public GuideController(IGuideService IGuideService)
        {
            _GuideService = IGuideService;
        }


        // GET api/<controller>/5
        /// <summary>
        /// Get Guide by id
        /// </summary>
        /// <param name="id"> Guide Id </param>
        /// <returns>GuideDto</returns>
        [HttpGet]
        [Route("~/api/Guide/{id}")]
        public GuideDto Get(int id)
        {
            var model = _GuideService.GetById(CurrentLanguage, id);
            if (model != null)
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetById_NotExist));

        }
        /// <summary>
        /// Get Base Guides
        /// </summary>
        /// <returns>list from GuideDto</returns>
        [HttpGet]
        [Route("~/api/Guide/GetBaseGuides")]
        public List<GuideDto> GetBaseGuides()
        {
            var model = _GuideService.GetBaseGuides(CurrentLanguage);
            if (model.Any())
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetBaseCategory_NotExist));

        }
        /// <summary>
        /// Get the children of the guide
        /// </summary>
        /// <param name="GuideId"></param>
        /// <returns>List from GuideDto</returns>

        [HttpGet]
        [Route("~/api/Guide/GetChildGuide")]
        public List<GuideDto> GetChildGuide(int GuideId)
        {
            var model = _GuideService.GetChildGuide(CurrentLanguage, GuideId);
            if (model.Any())
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetChildCategory_NotExist));
        }
        /// <summary>
        /// Get Guide tree
        /// </summary>
        /// <param name="GuideID"></param>
        /// <returns>GuideDto</returns>
        [HttpGet]
        [Route("~/api/Guide/GetGuideTree")]
        public GuideDto GetGuideTree(int GuideID)
        {

            var model = _GuideService.GetGuideTree(CurrentLanguage, GuideID);
            if (model!=null)
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetChildCategory_NotExist));
        }

        /// <summary>
        /// Get grandchildren of this guide
        /// </summary>
        /// <param name="GuideId"></param>
        /// <returns>List from GuideDto</returns>
        [HttpGet]
        [Route("~/api/Guide/GetSortedSubChildrenGuide")]
        public List<GuideDto> GetSortedSubChildrenGuide(int GuideId)
        {
            
            var model = _GuideService.GetSortedSubChildrenGuide(CurrentLanguage, GuideId);
            if (model!=null)
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetChildCategory_NotExist));
        }
        //  [Authorize(Roles = "DeveloperRole,AdminRole")]
        /// <summary>
        /// Path this guide
        /// </summary>
        /// <param name="GuideId"></param>
        /// <returns>Path guide as string</returns>
        [HttpGet]
        [Route("~/api/Guide/CategoryPathFinder")]
        public string GuidePathFinder(int GuideId)
        {
           
            var model = _GuideService.GuidePathFinder(CurrentLanguage, GuideId);
            if (model.Length>0)
                return model;
            else
                throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_PathFinder_NotExist));
        }


        /// <summary>
        /// Get all guides
        /// </summary>
        /// <returns>List from GuideDto</returns>
        [HttpGet]
        [Route("~/api/Guide/GetAll")]
        public List<GuideDto> GetAll()
        {
            var model= _GuideService.GetAll(CurrentLanguage);
            if (model.Any())
                return model;
            else
                throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_PathFinder_NotExist));

        }


    }
}