using NawafizApp.Common;
using Microsoft.AspNet.Identity;
using NawafizApp.Common;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace NawafizApp.Web.Controllers
{
    public class AppController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IRegionService _regionservice;
        IBranchService _branchService;
        IShopDalService _shopDalService;
        INotificationService _INotificationService;
        public AppController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, IRegionService regionservice,INotificationService ins, IBranchService branchService, IShopDalService shopDalService)
            : base(userManager, aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._regionservice = regionservice;
            this._branchService = branchService;
            this._shopDalService = shopDalService;
            this._INotificationService = ins;
        }
        [Authorize(Roles ="Admin")]
        public ActionResult addFavourite()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addFavourite(FavouriteDto dto)
        {
            dto.userid = getGuid(User.Identity.GetUserId());
            var b = _INotificationService.AddFavourite(dto);
            return RedirectToAction("addFavourite");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult editFavourite()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editFavourite(FavouriteDto dto)
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult deleteFavourite()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult getAllFavourite()
        {
      

            return View(_INotificationService.getAllfavourite());
        
    }
        [Authorize(Roles = "Admin")]

        public ActionResult deleteFvourite(int id)
        {
            var x = _INotificationService.deletefavourite(id);
            if (x)
                return RedirectToAction("addFavourite");
            return RedirectToAction("Error","Account");
        }

        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int id)
        {

            var dto = _INotificationService.GetById(id);
            return View(dto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FavouriteDto dto)
        {

            if (ModelState.IsValid)
            {

                _INotificationService.Edit(dto);
                return RedirectToAction("addFavourite", "App");

            }
            return View(dto);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult addFavouriteNotification()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addFavouriteNotification(NotificationDto dto,string date,List<string> favouritid)
        {
            List<int> list = new List<int>();
            foreach (var item in favouritid)
            {
                dto.impid = Convert.ToInt32(item);
                list.Add(dto.impid);
            }
            dto.senderId = getGuid(User.Identity.GetUserId());
            dto.date = Utils.ServerNow.Date;
            dto.time = Utils.ServerNow.TimeOfDay;
       
            var b = _INotificationService.createfavouritNotification(dto,list);
            return RedirectToAction("addFavouriteNotification");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult addfollowerNotification()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addfollowerNotification(NotificationDto dto, string date, List<string> shopids)
        {
            List<int> list = new List<int>();
            foreach (var item in shopids)
            {
                dto.impid = Convert.ToInt32(item);
                list.Add(dto.impid);
            }
            dto.senderId = getGuid(User.Identity.GetUserId());
            dto.date = Utils.ServerNow.Date;
            dto.time = Utils.ServerNow.TimeOfDay;
            var b = _INotificationService.createfollowerNotification(dto, list);
            return RedirectToAction("addfollowerNotification");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult addAllNotification()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addAllNotification(NotificationDto dto, string date)
        {
        
            dto.senderId = getGuid(User.Identity.GetUserId());
            dto.date = Utils.ServerNow.Date;
            dto.time = Utils.ServerNow.TimeOfDay;
            var b = _INotificationService.createAllNotification(dto);
            return RedirectToAction("addAllNotification");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Search()
        {
        
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult getAllUsersNotification(string title, string shopDalName,string start,string end)
        {
          
            if (Request.IsAjaxRequest())
            {
                if (!String.IsNullOrEmpty(title)&&String.IsNullOrEmpty(start)&&String.IsNullOrEmpty(end)) {
                    return View(_INotificationService.getAllUsersNotification().Where(x=>x.title.Contains(title)));
                }
                if ( !String.IsNullOrEmpty(start) && !String.IsNullOrEmpty(end))
                {
                    return View(_INotificationService.getAllUsersNotification().Where(x => x.date>=DateTimeHelper.ConvertStringToDate(start,DateFormats.DD_MM_YYYY)&&x.date<=DateTimeHelper.ConvertStringToDate(end,DateFormats.DD_MM_YYYY)));
                }
                if (!String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(start) && !String.IsNullOrEmpty(end))
                {
                    return View(_INotificationService.getAllUsersNotification().Where(x => x.date >= DateTimeHelper.ConvertStringToDate(start, DateFormats.DD_MM_YYYY) && x.date <= DateTimeHelper.ConvertStringToDate(end, DateFormats.DD_MM_YYYY)&&x.title.Contains(title)));
                }
              
            }
            return View(_INotificationService.getAllUsersNotification());
        }

    }
}