using NawafizApp.Services.Dtos;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using NawafizApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NawafizApp.Web.Controllers
{
    public class NeiborHoodController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IRegionService _regionservice;
        INeihborhoodService _neihborhoodservice;
        public NeiborHoodController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, IRegionService regionservice,INeihborhoodService neiborhoodservice)
            :base(userManager,aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._regionservice = regionservice;
            this._neihborhoodservice = neiborhoodservice;
        }
        [Authorize(Roles = "Admin")]

        public ActionResult addNeihborhood() {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult addNeihborhood(NeihborhoodDto dto) {

            var i = _neihborhoodservice.addNeiborHood(dto);
            return RedirectToAction("addNeihborhood");
        }

        [Authorize(Roles = "Admin")]
  
        public ActionResult deleteNeiborHood(int id)
        {
            var x = _neihborhoodservice.deleteNeiborHood(id);
            if (x)
                return RedirectToAction("addNeihborhood");
            return RedirectToAction("Error");
        }
        [Authorize(Roles = "Admin")]
    
        public ActionResult Edite(int id) {
            var i = _neihborhoodservice.GetById(id);
            i.stateId = _neihborhoodservice.getAllNeiborHood().Find(x => x.Id == id).stateId;
            ViewBag.RegionId = _neihborhoodservice.getAllNeiborHood().Find(x => x.Id == id).RegionId.ToString();
            ViewBag.regionAName = _neihborhoodservice.getAllNeiborHood().Find(x => x.Id == id).regionAName;
            
            return View(i);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edite(NeihborhoodDto dto) {
            if (ModelState.IsValid)
            {

                _neihborhoodservice.Edit(dto);
                return RedirectToAction("addNeihborhood", "NeiborHood");

            }
            return View(dto);
        }
        [Authorize(Roles = "Admin")]
   
        public ActionResult getAllNeiborHood(int? state = -100, int? region = -100)
        {
            if (Request.IsAjaxRequest())
            {
                if (state != -100 && region == -100)
                {
                    return PartialView(_neihborhoodservice.getAllNeiborHood().OrderByDescending(x => x.Id).Where(x => x.stateId == state.Value).OrderBy(x => x.regionAName).OrderBy(x => x.statename));
                }
                if (state != -100 && region != -100)
                {
                    return PartialView(_neihborhoodservice.getAllNeiborHood().OrderByDescending(x => x.Id).Where(x => x.stateId == state.Value&&x.RegionId==region.Value).OrderBy(x => x.regionAName).OrderBy(x => x.statename));
                }
            }
            return View(_neihborhoodservice.getAllNeiborHood().OrderByDescending(x => x.Id).OrderBy(x => x.regionAName).OrderBy(x => x.statename));
        }

        [Authorize(Roles = "Admin")]

        public JsonResult getConvinientRegions(int sid)
        {
            var data = Selects.regionsByState(null, sid);
            return Json(data);
        }
      


    }
}