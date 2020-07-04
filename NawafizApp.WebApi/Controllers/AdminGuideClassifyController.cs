using GoogleMaps.LocationServices;
using Google.Maps.Geocoding;
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



namespace NawafizApp.WebApi.Controllers
{
    public class AdminGuideClassifyController : ApiAuthorizeBaseController
    {
        private readonly IGuideClassifyService _GuideClassifyService;

        public AdminGuideClassifyController(IGuideClassifyService IGuideClassifyService, ApplicationUserManager userManager):base(userManager)
        {
            _GuideClassifyService = IGuideClassifyService;
        }
        /// <summary>
        /// Add Guide Classify 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>return classify Id</returns>
   //   [Authorize]
        [ValidateModel]
        [HttpPost]
        [Route("~/api/AdminGuideClassifyController/AddClassify")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int AddClassify(InputGuideClassifyDto dto)
        {//LanguageHelper CurrentLanguage,
            
            var addC = _GuideClassifyService.AddGuideClassify(CurrentLanguage, dto);
            if (addC != null)
                return (int)addC;
            else
                throw new HttpResponseException(NotFoundMessage("موقع المنطقة لايتطابق مع موقعك"));

          //  return _ClassifyService.AddFeaturedClassify(CurrentLanguage, dto, guid);
            // return _languageService.Add(dto);
        }

        /// <summary>
        /// Update a classify
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>return true if if updated correctly , and false if not</returns>
        [ValidateModel]
        [HttpPut]
        [Route("~/api/AdminGuideClassifyController/EditClassify")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool EditClassify(InputGuideClassifyDto dto)
        {
           

            var EditC = _GuideClassifyService.EditGuideClassify(CurrentLanguage, dto);
            if (EditC != null)
                return (bool)EditC;
            else
                throw new HttpResponseException(NotFoundMessage("موقع المنطقة لايتطابق مع موقعك"));

            // return _ClassifyService.EditFeaturedClassify(CurrentLanguage, dto, guid);
        }
        /// <summary>
        /// Change classify state
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns>return true if if updated correctly , and false if not</returns>
        [HttpPut]
        [Route("~/api/AdminGuideClassifyController/ChangeClassifyState")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool ChangeClassifyState(int id, ClassifyStateHelper state)
        {
            return _GuideClassifyService.ChangeGuideClassifyState(id, state);
        }


        /// <summary>
        /// Delete a classify by classsify Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return true if If deleted correctly , and false if not</returns>
        [HttpDelete]
        [Route("~/api/AdminGuideClassifyController/Delete")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool Delete(int id)
        {
            return _GuideClassifyService.Delete(id);
        }

        #region Photos

        /// <summary>
        /// Delete classify image
        /// </summary>
        /// <param name="ClassifyId"></param>
        /// <param name="ImageUrl"></param>
        /// <returns>return true if If deleted correctly , and false if not</returns>
        [HttpPut]
        [Route("~/api/AdminGuideClassifyController/DeleteImage")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool DeleteImage(int ClassifyId, string ImageUrl)
        {
            return _GuideClassifyService.DeleteImage(ClassifyId, ImageUrl);
        }

        /// <summary>
        /// Add image to a classify
        /// </summary>
        /// <param name="extension">Extension of image without dot</param>
        /// <param name="ClassifyId">Classify Id</param>
        /// <param name="IsPrimary">True if this image is primary , and false if not</param>
        /// <returns>return URL of this Image</returns>
        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/AdminGuideClassifyController/TestPostImageBase64")]
        public async Task<string> TestPostImageBase64(string extension, int ClassifyId, bool IsPrimary)
        {
            string PATH = HttpContext.Current.Server.MapPath("~/UploadImages");
            string imageData = await Request.Content.ReadAsStringAsync();

            //byte[] bytes = Convert.FromBase64String("/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAKBueIx4ZKCMgoy0qqC+8P//8Nzc8P//////////////////////////////////////////////////////////2wBDAaq0tPDS8P//////////////////////////////////////////////////////////////////////////////wAARCAAKAAoDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwBVUFQSOf51HRRSND//2Q==");
            byte[] bytes = Convert.FromBase64String(imageData);
            Image image;
            Guid g = Guid.NewGuid();
            extension = extension.ToLower();

            Guid UserGuid = getCurrentUserGuid();

            if (extension == "jpg" || extension == "png" || extension == "Gif")
            {

                if (_GuideClassifyService.AddImageToGuideClassify(ClassifyId, IsPrimary, g.ToString() + "." + extension))
                {
                    // int g = 1010101;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        image = Image.FromStream(ms);
                        switch (extension)
                        {
                            case "jpg":
                                image.Save(PATH + "/" + g.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case "png":
                                image.Save(PATH + "/" + g.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case "gif":
                                image.Save(PATH + "/" + g.ToString() + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                                break;
                            default:
                                break;
                        }

                    }


                    return Utils.ImageURL + g.ToString() + "." + extension.ToLower();
                }
                else
                    throw new HttpResponseException(NotFoundMessage("تأكد من ClassifyId"));
            }
            else
                throw new HttpResponseException(NotFoundMessage("الرجاء إدخال امتداد صحيح"));
            //  return string.Join(Url.Content("~/UploadImages/"),"", g.ToString() + "." + extension.ToLower());
        }

        #endregion


        //[HttpGet]
        //[Route("~/api/AdminClassify/asearch_test")]
        //[ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        //public IEnumerable<string> asearch_test(double lon, double lan)
        //{
        //    var address = "منطقة اللاذقية" + "," + "اللاذقية";
        //    // string s_address = "," + "اللاذقية";
        //    var locationService = new GoogleLocationService();
        //    // GoogleMaps.LocationServices.GoogleLocationService r = locationService.GetRegionFromLatLong(lat, lon);
        //    // LocationServices  r = new GoogleMaps.LocationServices();

        //    //   r= locationService.GetRegionFromLatLong(lat, lon);
        //    var g = new GeocodingRequest();

        //    var address_gps =
        //  g.Address = address;
        //    // g.Region = r.Name;
        //    g.Sensor = false;
        //    g.Language = "ar";
        //    var response = new GeocodingService().GetResponse(g);



        //    var point = locationService.GetLatLongFromAddress(address);
        //    AddressData a = locationService.GetAddressFromLatLang(lon, lan);
        //    //  Directions dir=  locationService.GetDirections(point.Latitude, point.Longitude);
        //    var s = _ClassifyService.search_test(lon.ToString() + "," + lan.ToString());
        //    //yield return response.Results[0].PlaceId;
        //    return s;
        //    //  yield return locationService.GetAddressFromLatLang(5 , lon).Address;
        //    // return "s";




        //    // return _ClassifyService.search_test(town);
        //}


    }
}