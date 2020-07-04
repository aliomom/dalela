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
    public class CategoryController : ApiBaseController
    {


        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService ICategoryService)
        {
            _CategoryService = ICategoryService;
        }


        // GET api/<controller>/5
        /// <summary>
        /// Get Category by id
        /// </summary>
        /// <param name="id"> Category Id </param>
        /// <returns>CategoryDto</returns>
        [HttpGet]
        [Route("~/api/Category/{id}")]
        public CategoryDto Get(int id)
        {
            var model = _CategoryService.GetById(CurrentLanguage, id);
            if (model != null)
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetById_NotExist));

        }
        /// <summary>
        /// Get Base Categories
        /// </summary>
        /// <returns>CategoryDto</returns>
        [HttpGet]
        [Route("~/api/Category/GetBaseCategories")]
        public List<CategoryDto> GetBaseCategories()
        {
            var model = _CategoryService.GetBaseCategories(CurrentLanguage);
            if (model.Any())
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetBaseCategory_NotExist));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>CategoryDto</returns>

        [HttpGet]
        [Route("~/api/Category/GetChildCategory")]
        public List<CategoryDto> GetChildCategory(int categoryId)
        {
            var model = _CategoryService.GetChildCategory(CurrentLanguage, categoryId);
            if (model.Any())
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetChildCategory_NotExist));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns>CategoryDto</returns>
        [HttpGet]
        [Route("~/api/Category/GetCategoryTree")]
        public CategoryDto GetCategoryTree(int CategoryID)
        {

            var model = _CategoryService.GetCategoryTree(CurrentLanguage,CategoryID);
            if (model!=null)
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetChildCategory_NotExist));
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>CategoryDto</returns>
        [HttpGet]
        [Route("~/api/Category/GetSortedSubChildrenCategory")]
        public List<CategoryDto> GetSortedSubChildrenCategory(int categoryId)
        {
            
            var model = _CategoryService.GetSortedSubChildrenCategory(CurrentLanguage, categoryId);
            if (model.Any())
                return model;
            throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_GetChildCategory_NotExist));
        }
        //  [Authorize(Roles = "DeveloperRole,AdminRole")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/Category/CategoryPathFinder")]
        public string CategoryPathFinder(int CategoryId)
        {
           
            var model = _CategoryService.CategoryPathFinder(CurrentLanguage, CategoryId);
            if (model.Any())
                return model;
            else
                throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_PathFinder_NotExist));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>CategoryDto</returns>
        [HttpGet]
        [Route("~/api/Category/GetAll")]
        public List<CategoryDto> GetAll()
        {
            var model= _CategoryService.GetAll(CurrentLanguage);
            if (model.Any())
                return model;
            else
                throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_PathFinder_NotExist));

        }


    }
}