using Microsoft.Owin.Security;
using NawafizApp.Common;
using NawafizApp.Common.Resources;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using NawafizApp.WebApi.ActionFilters;
using NawafizApp.WebApi.Attributes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NawafizApp.WebApi.Controllers
{
    public class GuideClassifyController : ApiAuthorizeBaseController
    {
        private readonly IGuideClassifyService _GuideClassifyService;
        
        public GuideClassifyController(IGuideClassifyService IGuideClassifyService, ApplicationUserManager userManager):base(userManager)
        {
            _GuideClassifyService = IGuideClassifyService;

            
        }

        #region Search
        //[Authorize]
        //[HttpPut]
        //[Route("~/api/Classify/GetAuthorize")]
        //public GuideClassifySimplifyDto GetAuthorize(SClassifyDto search)
        //{
        //    var model = _GuideClassifyService.GetById(CurrentLanguage, search,getCurrentUserGuid(),ClassifyStateHelper.ACTIVE);
        //    if (model != null)
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_BadID));

        //}

        /// <summary>
        /// Search in guide classify
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/GuideClassifyController/SearchAuthorize")]
        public IPagedList<GuideClassifySimplifyDto> SearchAuthorize(GuideSearchClassifyDto search)
        {

            var pageNumber = search.page ?? 1;
            
            var model = _GuideClassifyService.Search(CurrentLanguage, search, getCurrentUserGuid());
            if (model.Any())
            {
                
                var x = model.ToPagedList(pageNumber, search.pageSize);
                return x;
            }
            throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        }
        [Authorize]
        [HttpGet]
        [Route("~/api/GuideClassifyController/GetDeatailedByIdAuthorize")]
        public GuideClassifyDetailedDto GetDeatailedByIdAuthorize(int id)
        {

            // var pageNumber = search.page ?? 1;
            var model = _GuideClassifyService.GetDeatailedById(CurrentLanguage, id, getCurrentUserGuid(), ClassifyStateHelper.ACTIVE);
            if (model != null)
            {
                //  var x = model.ToPagedList(pageNumber, search.pageSize);
                return model;
            }
            throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        }
       
        [HttpGet]
        [Route("~/api/GuideClassifyController/GetDeatailedById")]
        public GuideClassifyDetailedDto GetDeatailedById(int id)
        {

            // var pageNumber = search.page ?? 1;
            var model = _GuideClassifyService.GetDeatailedById(CurrentLanguage, id, getCurrentUserGuid(), ClassifyStateHelper.ACTIVE);
            if (model != null)
            {
                //  var x = model.ToPagedList(pageNumber, search.pageSize);
                return model;
            }
            throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        }


        //[HttpPut]
        //[Route("~/api/Classify/Get")]
        //public ClassifySimplifyDto Get(SClassifyDto search)
        //{
        //    var model = _ClassifyService.GetById(CurrentLanguage, search, getCurrentUserGuid(),ClassifyStateHelper.ACTIVE);
        //    if (model != null)
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_BadID));

        //}


        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/GuideClassifyController/Search")]
        public IPagedList<GuideClassifySimplifyDto> Search(GuideSearchClassifyDto search)
        {

            var pageNumber = search.page ?? 1;

            var model = _GuideClassifyService.Search(CurrentLanguage, search, getCurrentUserGuid());
            if (model.Any())
            {

                var x = model.ToPagedList(pageNumber, search.pageSize);
                return x;
            }
            throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        }

        //[HttpGet]
        //[Route("~/api/Classify/GetDeatailedById")]
        //public ClassifyDetailedDto GetDeatailedById(int id)
        //{

        //    // var pageNumber = search.page ?? 1;
        //    var model = _ClassifyService.GetDeatailedById(CurrentLanguage, id, getCurrentUserGuid(),ClassifyStateHelper.ACTIVE);
        //    if (model != null)
        //    {
        //        //  var x = model.ToPagedList(pageNumber, search.pageSize);
        //        return model;
        //    }
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        //}

        ///// <summary>
        ///// Not used
        ///// </summary>
        ///// <param name="PublisherId"></param>
        ///// <param name="search"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/Classify/GetByPublisherId")]
        //public List<ClassifySimplifyDto> GetByPublisherId(Guid PublisherId, SClassifyDto search)
        //{
        //    var model = _ClassifyService.GetByPublisherId(CurrentLanguage, search);
        //    if (model.Any())
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        //}
        ///// <summary>
        ///// Not used
        ///// </summary>
        ///// <param name="search"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/Classify/GetByCategoryId")]
        //public List<ClassifySimplifyDto> GetByCategoryId(SClassifyDto search)
        //{
        //    var model = _ClassifyService.GetByCategoryId(CurrentLanguage, search);
        //    if (model.Any())
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        //}

        ///// <summary>
        ///// Not used
        ///// </summary>
        ///// <param name="search"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/Classify/GetByCity")]
        //public List<ClassifySimplifyDto> GetByCity(SClassifyDto search)
        //{

        //    var model = _ClassifyService.GetByCity(CurrentLanguage, search);
        //    if (model.Any())
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        //}


        ///// <summary>
        ///// Not used
        ///// </summary>
        ///// <param name="search"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/Classify/GetByPrice")]
        //public List<ClassifySimplifyDto> GetByPrice(SClassifyDto search)
        //{
        //    var model = _ClassifyService.GetByPrice(CurrentLanguage, search);
        //    if (model.Any())
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        //}

        ///// <summary>
        ///// Not used
        ///// </summary>
        ///// <param name="search"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/Classify/GetByDate")]
        //public List<ClassifySimplifyDto> GetByDate(SClassifyDto search)
        //{
        //    var model = _ClassifyService.GetByDate(CurrentLanguage, search);
        //    if (model.Any())
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        //}


        ///// <summary>
        ///// Not used
        ///// </summary>
        ///// <param name="search"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/Classify/GetSortedByCategoryId")]
        //public List<ClassifySimplifyDto> GetSortedByCategoryId(SClassifyDto search)
        //{
        //    var model = _ClassifyService.GetSortedByCategoryId(CurrentLanguage, search);
        //    if (model.Any())
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        //}


        ///// <summary>
        ///// Not used
        ///// </summary>
        ///// <param name="search"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/Classify/GetSortedByCategoryId_and_ByCity")]
        //public List<ClassifySimplifyDto> GetSortedByCategoryId_and_ByCity(SClassifyDto search)
        //{
        //    var model = _ClassifyService.GetSortedByCategoryId_and_ByCity(CurrentLanguage, search);
        //    if (model.Any())
        //        return model;
        //    throw new HttpResponseException(NotFoundMessage(STRING.ClassifyController_NOClassifies));

        //}
        #endregion





        //[AllowAnonymous]
        //[HttpPost]
        //[Route("~/api/Classify/TestPostImageBase64")]
        //public async Task<string> TestPostImageBase64(string extension,int CatigoryId)
        //{
        //    string PATH = HttpContext.Current.Server.MapPath("~/UploadImages");
        //    string imageData = await Request.Content.ReadAsStringAsync();

        //    //byte[] bytes = Convert.FromBase64String("/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAKBueIx4ZKCMgoy0qqC+8P//8Nzc8P//////////////////////////////////////////////////////////2wBDAaq0tPDS8P//////////////////////////////////////////////////////////////////////////////wAARCAAKAAoDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwBVUFQSOf51HRRSND//2Q==");
        //    byte[] bytes = Convert.FromBase64String(imageData);
        //    Image image;
        //    Guid g = Guid.NewGuid();
        //   // int g = 1010101;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = Image.FromStream(ms);
        //        switch (extension.ToLower())
        //        {
        //            case "jpg":
        //                image.Save(PATH + "/" + g.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //                break;
        //            case "png":
        //                image.Save(PATH + "/" + g.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
        //                break;
        //            case "gif":
        //                image.Save(PATH + "/" + g.ToString() + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
        //                break;
        //            default:
        //                break;
        //        }

        //    }

        //    return Utils.ImageURL + g.ToString() + "." + extension.ToLower();
        //  //  return string.Join(Url.Content("~/UploadImages/"),"", g.ToString() + "." + extension.ToLower());
        //}
    }
}