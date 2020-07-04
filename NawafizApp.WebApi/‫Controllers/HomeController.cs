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
        
      //  AndroidVersionService _androidService;
        public HomeController()
        {
        
        }
        

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        
    }
}
