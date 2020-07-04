using NawafizApp.Services.Dtos;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using NawafizApp.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NawafizApp.WebApi._Controllers
{
    public class ArabicController : ApiAuthorizeBaseController
    {
        private readonly IArabicServiceAPI _IArabicServiceAPI;
       

        public ArabicController(IArabicServiceAPI IArabicServiceAPI, ApplicationUserManager um):base(um)

        {
            _IArabicServiceAPI = IArabicServiceAPI;
        }
        /// <summary>
        /// Get all main categories[ ARABIC ]
        /// </summary>
        /// <param ></param>
        /// <returns>list of main categories</returns>
        [HttpGet]
        [Route("~/api/Arabic/GetAllMainCategories")]
        public List<APIMainCategoryDtoAr> GetAllMainCategories( string slug)
        {
            var model = _IArabicServiceAPI.getAllArabicMainCategories(slug);
            return model;
        }
        /// <summary>
        /// Get all Sub categories by passing MainCategoryId [ ARABIC ]
        /// </summary>
        /// <param ></param>
        /// <returns>list of sub categories</returns>
        [HttpGet]
        [Route("~/api/Arabic/GetAllSubCategoriesByMainCategory")]
        public List<APISubCategoryDtoAr> GetAllSubCategoriesByMainCategory(int MainCategoryId,string slug)
        {
            var model = _IArabicServiceAPI.getAllSubCategoriesByMainCategory(MainCategoryId,slug);
            return model;
        }

        /// <summary>
        /// Get all States 
        /// </summary>
        /// <param >none</param>
        /// <returns>list of States/returns>
        [HttpGet]
        [Route("~/api/Arabic/getAllStates")]
        public List<APIStateDtoArabic> getAllStates(string slug)
        {
            var model = _IArabicServiceAPI.getAllStates(slug);
            return model;
        }
        /// <summary>
        /// Get all regions by stateId [ ARABIC ]
        /// </summary>
        /// <param >stateId</param>
        /// <returns>list of regions/returns>
        [HttpGet]
        [Route("~/api/Arabic/getRegionsByState")]
        public List<APIRegionDtoArabic> getRegionsByState(int stateId ,string slug)
        {
            var model = _IArabicServiceAPI.getAllRegions(stateId,slug);
            return model;
        }
        /// <summary>
        /// Get all shops by passing subCategoryId 
        /// this fuction will return convinient result whether you pass state id alone and leave region id 'null'
        /// or pass them together 
        /// or pass both null (in this case it filter shops by sub category only)
        /// [ ARABIC ]
        /// </summary>
        /// <param >subcatId required......stateId optional...regionId optional</param>
        /// <returns>list of Shops with name and id</returns>
        [HttpGet]
        [Route("~/api/Arabic/GetAllShopsBySubCategory")]
        public List<APIShopsDisplayDtoAr> GetAllShopsBySubCategory(int SubCategoryId,int? stateId,int? regionId,string slug)
        {
            var model = _IArabicServiceAPI.getShopsBySubCat(SubCategoryId,stateId,regionId,slug);
            return model;
        }
        /// <summary>
        /// get all offers by a sub category you must pass if that offer is an admin offer
        /// </summary>
        /// <param >subcatId required......isAdminOffer required...slug required</param>
        /// <returns>list of Shops with name and id</returns>
        [HttpGet]
        [Route("~/api/Arabic/getOffersbySubcategory")]
        public List<APIDisplayOffersOfSubCatDto> getOffersbySubcategory(int SubCategoryId,bool? isAdminOffer , string slug)
        {
            if (!isAdminOffer.HasValue)
            {
                throw new HttpResponseException(NotFoundMessage("لا يمكن الاستدعاء بدون تمرير المتحول IsAdminOffer"));
            }
            var model = _IArabicServiceAPI.getoffersBySubCat(SubCategoryId, isAdminOffer.Value, slug);
            return model;
        }
        /// <summary>
        /// Get all offers sub categories[ ARABIC ]
        /// </summary>
        /// <param ></param>
        /// <returns>list of offers sub categories</returns>
        [HttpGet]
        [Route("~/api/Arabic/GetAllOffersSubCategories")]
        public List<APIOffersSubCategiesDtoAr> GetAllOffersSubCategories( string slug)
        {
            var model = _IArabicServiceAPI.getAllOffersSubCategories(slug);
            return model;
        }
        /// <summary>
        /// get shop details[ ARABIC ]
        /// </summary>
        /// <param >id of shop</param>
        /// <returns>shop details</returns>
        [HttpGet]
        [Route("~/api/Arabic/GetShopById")]
        public APIShopWithBranchesDtoAr GetShopById(int shopId,string slug)
        {
            var model = _IArabicServiceAPI.getbranchById(shopId,slug);
            return model;
        }
        /// <summary>
        /// Get an offer by passing its id ,,, the boolean parameter must be passed
        /// </summary>
        /// <param ></param>
        /// <returns>APIofferDto object</returns>
        [HttpGet]
        [Route("~/api/Arabic/GetOfferAr")]
        public APIOfferDtoAr GetOfferAr(int id , bool? isAdminOffer , string slug)
        {
            if (isAdminOffer == null) { throw new HttpResponseException(NotFoundMessage("لا يمكن الاستدعاء بدون تمرير المتحول IsAdminOffer"));  }
            var model = _IArabicServiceAPI.getOfferById(id,isAdminOffer.Value , slug);
            return model;
        }
    }
}
