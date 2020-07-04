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
    public class HomeController : Controller
    {
        IAndroidVersionService _androidService;
      //  AndroidVersionService _androidService;
        public HomeController(IAndroidVersionService iAndroidService)
        {
            _androidService = iAndroidService;
        }
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAndroidVersion()
        {
           var andr= _androidService.GetAll();
           
            ViewBag.Android = andr;
            return View();
        }
        public ActionResult AddAndroidVersion(AndroidVersionDto dto)
        {
            _androidService.Add(dto);
          return RedirectToAction("AndroidVersion");
        }
    }
}
