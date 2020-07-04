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
    public class RegionController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IRegionService _regionservice;
        public RegionController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice,IRegionService regionservice)
            :base(userManager,aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._regionservice = regionservice;
        }
        [Authorize(Roles = "Admin")]
   
        public ActionResult AddRegion()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddRegion(RegionDto dto)
        {
            int ri = _regionservice.addRegion(dto);

            return RedirectToAction("AddRegion");
        }
        [Authorize(Roles = "Admin")]
     

        public ActionResult getAllRegion()
        {
            return View(_regionservice.getAllRegions().OrderBy(x => x.ArabicName).OrderByDescending(x => x.Id));
        }
        [Authorize(Roles = "Admin")]
      
        public ActionResult deleteRegion(int id)
        {
            var x = _regionservice.deleteRegion(id);
            if (x)
                return RedirectToAction("AddRegion");
            return RedirectToAction("Error");
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int id)
        {

            var dto = _regionservice.GetById(id);
            return View(dto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegionDto regionDto)
        {

            if (ModelState.IsValid)
            {

                _regionservice.Edit(regionDto);
                return RedirectToAction("AddRegion", "Region");

            }
            return View(regionDto);
        }
    }
}