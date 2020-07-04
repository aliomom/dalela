using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using NawafizApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NawafizApp.WebApi.Controllers
{
    public class ZAndroidController : Controller
    {
        IAndroidVersionService _androidService;
      //  AndroidVersionService _androidService;
      /// <summary>
      /// 
      /// </summary>
      /// <param name="iAndroidService"></param>
        public ZAndroidController(IAndroidVersionService iAndroidService)
        {
            _androidService = iAndroidService;
        }
       

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public ActionResult GetAndroidVersion()
        {
           var andr= _androidService.GetAll();
           
            ViewBag.Android = andr;
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddAndroidVersion(AndroidVersionDto dto)
        {
            _androidService.Add(dto);
          return RedirectToAction("AndroidVersion");
        }
    }
}
