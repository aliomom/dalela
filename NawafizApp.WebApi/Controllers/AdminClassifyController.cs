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
    public class AdminClassifyController : ApiAuthorizeBaseController
    {
        private readonly IClassifyService _ClassifyService;

        public AdminClassifyController(IClassifyService IClassifyService, ApplicationUserManager userManager):base(userManager)
        {
            _ClassifyService = IClassifyService;
        }

        [Authorize]
        [ValidateModel]
        [HttpPost]
        [Route("~/api/AdminClassify/AddFeaturedClassify")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int AddFeaturedClassify(InputClassifyDto dto)
        {//LanguageHelper CurrentLanguage,
            Guid guid = getCurrentUserGuid();
            var addC = _ClassifyService.AddFeaturedClassify(CurrentLanguage, dto, guid);
            if (addC != null)
                return (int)addC;
            else
                throw new HttpResponseException(NotFoundMessage("موقع المنطقة لايتطابق مع موقعك"));

          //  return _ClassifyService.AddFeaturedClassify(CurrentLanguage, dto, guid);
            // return _languageService.Add(dto);
        }

        [Authorize]
        [ValidateModel]
        [HttpPut]
        [Route("~/api/AdminClassify/EditFeaturedClassify")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool EditFeaturedClassify(InputClassifyDto dto)
        {
            Guid guid = getCurrentUserGuid();

            var EditC = _ClassifyService.EditFeaturedClassify(CurrentLanguage, dto, guid);
            if (EditC != null)
                return (bool)EditC;
            else
                throw new HttpResponseException(NotFoundMessage("موقع المنطقة لايتطابق مع موقعك"));

           // return _ClassifyService.EditFeaturedClassify(CurrentLanguage, dto, guid);
        }

       
        [HttpPut]
        [Route("~/api/Classify/ChangeClassifyToFeatured")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool ChangeClassifyToFeatured(int id)
        {
            return _ClassifyService.ChangeClassifyToFeatured(CurrentLanguage, id);
        }

      
        [HttpPut]
        [Route("~/api/AdminClassify/ChangeClassifyToNotFeatured")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool ChangeClassifyToNotFeatured(int id)
        {
            return _ClassifyService.ChangeClassifyToNotFeatured(CurrentLanguage, id);
        }
        public bool ChangeClassifyState(int id, ClassifyStateHelper state)
        {
            return _ClassifyService.ChangeClassifyState(id, state);
        }

        [Authorize]
        [ValidateModelAttribute]
        [HttpPost]
        [Route("~/api/AdminClassify/AddClassify")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int AddClassify(InputClassifyDto dto)
        {//LanguageHelper CurrentLanguage,
            Guid guid = getCurrentUserGuid();
            var addC= _ClassifyService.AddClassify(CurrentLanguage, dto, guid);
            if (addC != null)
                return (int)addC;
            else
                throw new HttpResponseException(NotFoundMessage("موقع المنطقة لايتطابق مع موقعك"));
            // return _languageService.Add(dto);
        }


        [Authorize]
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/AdminClassify/EditClassify")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool EditClassify(InputClassifyDto dto)
        {
            Guid guid = getCurrentUserGuid();

            var EditC = _ClassifyService.EditClassify(CurrentLanguage, dto, guid);
            if (EditC != null)
                return (bool)EditC;
            else
                throw new HttpResponseException(NotFoundMessage("موقع المنطقة لايتطابق مع موقعك"));

        }


        [HttpDelete]
        [Route("~/api/AdminClassify/Delete")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool Delete(int id)
        {
            return _ClassifyService.AdminDelete(id);
        }

        #region Photos
        [HttpPut]
        [Route("~/api/AdminClassify/DeleteImage")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool DeleteImage(int ClassifyId, string ImageUrl)
        {
            return _ClassifyService.DeleteImage(ClassifyId, ImageUrl,null);
        }
        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/AdminClassify/TestPostImageBase64")]
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

                if (_ClassifyService.AddImageToClassify(ClassifyId, UserGuid, IsPrimary, g.ToString() + "." + extension))
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
                    throw new HttpResponseException(NotFoundMessage("تأكد من ClassifyId ،أنت شخص غير مخول له بإضافة صورة لهذا الإعلان"));
            }
            else
                throw new HttpResponseException(NotFoundMessage("الرجاء إدخال امتداد صحيح"));
            //  return string.Join(Url.Content("~/UploadImages/"),"", g.ToString() + "." + extension.ToLower());
        }

        #endregion


        [HttpGet]
        [Route("~/api/AdminClassify/asearch_test")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public IEnumerable<string> asearch_test(double lon,double lan)
        {
            var address = "منطقة اللاذقية" + "," + "اللاذقية";
          // string s_address = "," + "اللاذقية";
            var locationService = new GoogleLocationService();
           // GoogleMaps.LocationServices.GoogleLocationService r = locationService.GetRegionFromLatLong(lat, lon);
        // LocationServices  r = new GoogleMaps.LocationServices();

        //   r= locationService.GetRegionFromLatLong(lat, lon);
            var g = new GeocodingRequest();

            var address_gps=
          g.Address = address;
           // g.Region = r.Name;
            g.Sensor = false;
            g.Language = "ar";
            var response = new GeocodingService().GetResponse(g);
           
           

            var point = locationService.GetLatLongFromAddress(address);
          AddressData a= locationService.GetAddressFromLatLang(lon, lan);
            //  Directions dir=  locationService.GetDirections(point.Latitude, point.Longitude);
            var s= _ClassifyService.search_test(lon.ToString()+","+lan.ToString());
            //yield return response.Results[0].PlaceId;
             return s;
            //  yield return locationService.GetAddressFromLatLang(5 , lon).Address;
           // return "s";




            // return _ClassifyService.search_test(town);
        }
        

    }
}