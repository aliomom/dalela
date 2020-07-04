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
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NawafizApp.WebApi.Controllers
{
    public class AdminCategoryController : ApiAuthorizeBaseController
    {
        private readonly ICategoryService _CategoryService;

        public AdminCategoryController(ICategoryService ICategoryService, ApplicationUserManager userManager):base(userManager)
        {
            _CategoryService = ICategoryService;
        }

       
        
        [HttpGet]
        [Route("~/api/AdminCategory/getLocation")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public string getLocation(string latLng)
        {//LanguageHelper Language,
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latLng + "&& sensor=true");

            XmlNodeList xNodelst = xDoc.GetElementsByTagName("result");
            XmlNode xNode = xNodelst.Item(0);
            string adress = xNode.SelectSingleNode("formatted_address").InnerText;
            string mahalle = xNode.SelectSingleNode("address_component[1]/long_name").InnerXml;
            string ilce = xNode.SelectSingleNode("address_component[2]/long_name").InnerXml;
            // string il = xNode.SelectSingleNode("address_component[4]/long_name").InnerXml;
            var root = new RootObject();

            var url =
                string.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latLng + "&& sensor=true");
            var req = (HttpWebRequest)WebRequest.Create(url);

            var res = (HttpWebResponse)req.GetResponse();

            using (var streamreader = new StreamReader(res.GetResponseStream()))
            {
                var result = streamreader.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(result))
                {
                    root = JsonConvert.DeserializeObject<RootObject>(result);
                }
            }
            var w = root.results.Where(m => m.types.Where(a=>a== "administrative_area_level_2").Any()).ToList()[0].address_components.ToList()[0].long_name;
            //string url = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?latlng="+latLng+"&sensor=false");
            //XElement xml = XElement.Load(url);
            //string res1;
            //// verifica se o status é ok
            //if (xml.Element("status").Value == "OK")
            //{
            //    //Formatar a resposta
            //    res1 = string.Format("<strong>Origem</strong>: {0}",
            //        //Pegar endereço de origem 
            //        xml.Element("result").Element("address_component").Value);
            //    //Pegar endereço de destino                    
            //}
            //else
            //{
            //    res1 = String.Concat("Ocorreu o seguinte erro: ", xml.Element("status").Value);
            //}
            return w;
            // return _languageService.Add(dto);
        }


        //  [Authorize(Roles = "DeveloperRole,AdminRole")]
        [ValidateModelAttribute]
        [HttpPost]
        [Route("~/api/AdminCategory/Add")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public int Add(InputCategoryDto dto)
        {//LanguageHelper Language,

            return _CategoryService.Add(CurrentLanguage, dto);
            // return _languageService.Add(dto);
        }



        //  [Authorize(Roles = "DeveloperRole,AdminRole")]
        [ValidateModelAttribute]
        [HttpPut]
        [Route("~/api/AdminCategory/Edit")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool Edit(InputCategoryDto dto)
        {
            return _CategoryService.Edit(CurrentLanguage, dto);
        }

        [HttpGet]
        [Route("~/api/AdminCategory/GetAll")]
        public List<CategoryAllDto> GetAll()
        {
            var model = _CategoryService.GetAll_for_Admin();
            if (model.Any())
                return model;
            else
                throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryController_PathFinder_NotExist));

        }


        // DELETE api/<controller>/5
        //  [Authorize(Roles = "DeveloperRole,AdminRole")]
        // [ValidateModelAttribute]
        [HttpDelete]
        [Route("~/api/AdminCategory/Delete")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotAcceptable, HttpStatusCode.Unauthorized)]
        public bool? Delete(int id)
        {
            var delete = _CategoryService.Delete(id);
            if (delete != null)
                return delete;
            else
                throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryAdminController_DeleteError));
        }

        
        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/AdminCategory/TestPostImageBase64")]
        public async Task<string> TestPostImageBase64(string extension, int CatigoryId)
        {
            string PATH = HttpContext.Current.Server.MapPath("~/UploadImages");
            string imageData = await Request.Content.ReadAsStringAsync();

            //byte[] bytes = Convert.FromBase64String("/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAKBueIx4ZKCMgoy0qqC+8P//8Nzc8P//////////////////////////////////////////////////////////2wBDAaq0tPDS8P//////////////////////////////////////////////////////////////////////////////wAARCAAKAAoDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwBVUFQSOf51HRRSND//2Q==");
            byte[] bytes = Convert.FromBase64String(imageData);
            Image image;
            Guid g = Guid.NewGuid();
            extension = extension.ToLower();
            if (extension == "jpg" || extension == "png" || extension == "Gif")
            {

                if (_CategoryService.AddImageToCategory(CatigoryId, g.ToString() + "." + extension))
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
                    throw new HttpResponseException(NotFoundMessage(CategoryResource.CategoryAdminController_CategoryId_NotFound));
            }
            else
            throw new HttpResponseException(NotFoundMessage(ClassifyResource.ClassifyController_ExtensionError));
            //  return string.Join(Url.Content("~/UploadImages/"),"", g.ToString() + "." + extension.ToLower());
        }

        
    }
}