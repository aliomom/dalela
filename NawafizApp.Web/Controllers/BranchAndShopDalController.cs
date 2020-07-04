using NawafizApp.Common;
using Microsoft.AspNet.Identity;
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
    public class BranchAndShopDalController : BaseAuthorizeController
    {
        IUserService _userService;
        IBranchAndShopDalService _BranchAndShopDalservice;
        public BranchAndShopDalController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IBranchAndShopDalService BranchAndShopDalservice)
            :base(userManager,aps)
        {

            this._userService = IUS;
            this._BranchAndShopDalservice = BranchAndShopDalservice;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult addBranchAndShopDal() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult addBranchAndShopDal(BranchAndShopDalDto dto,string start,string end,string facbooklink,string instalink,string outdays1, string outdays2, string outdays3, string outdays4, string outdays5, string outdays6, string outdays7)
        {
                  


             // dto.UserId = getGuid(User.Identity.GetUserId());

            if (!String.IsNullOrEmpty(dto.startstr))
            {
                dto.StartActiveTime = DateTimeHelper.ConvertStringToTime(dto.startstr, TimeFormats.HH_MM_AM);
            }
            if (!String.IsNullOrEmpty(dto.endstr))
            {
                dto.EndActiveTime = DateTimeHelper.ConvertStringToTime(dto.endstr, TimeFormats.HH_MM_AM);
            }                    

            dto.outDays = outdays1+" "+outdays2+" "+outdays3+" "+outdays4+" "+outdays5+" "+outdays6+" "+outdays7;
            if (String.IsNullOrEmpty(outdays1)&& String.IsNullOrEmpty(outdays2) && String.IsNullOrEmpty(outdays3) && String.IsNullOrEmpty(outdays4) && String.IsNullOrEmpty(outdays5) && String.IsNullOrEmpty(outdays6) && String.IsNullOrEmpty(outdays7) )
            {
                dto.outDays = null;
            }            
            int i = _BranchAndShopDalservice.AddBranchAndShopDal(dto);
            return RedirectToAction("addBranchAndShopDal");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult deleteBranchAndShopDal(int id,int bid)
        {
            var x = _BranchAndShopDalservice.deleteBranchAndShopDalDto(id, bid);
            if (x)
                return RedirectToAction("addBranchAndShopDal");
            return RedirectToAction("Error","Account");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id,int bid)
        {

            var dto = _BranchAndShopDalservice.GetById(id,bid);
            dto.startstr = DateTimeHelper.ConvertTimeToString(dto.StartActiveTime, TimeFormats.HH_MM_AM);
            dto.endstr = DateTimeHelper.ConvertTimeToString(dto.EndActiveTime, TimeFormats.HH_MM_AM);
            ViewBag.subid = dto.SubCategoryDalId.ToString() ;
            ViewBag.subname = dto.SubCategoryDalName;
            ViewBag.regionid = dto.regionId.ToString(); ;
            ViewBag.regionname = dto.regionName;
            ViewBag.neiborid = dto.NeighborhoodId.ToString();
            ViewBag.neiborname = dto.NeighborhoodName;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(BranchAndShopDalDto dto,int id,string start, string end, string facbooklink, string instalink, string outdays1, string outdays2, string outdays3, string outdays4, string outdays5, string outdays6, string outdays7)
        {

            if (ModelState.IsValid)
            {              
                dto.Id = id;
                if (!String.IsNullOrEmpty(dto.startstr))
                {
                    dto.StartActiveTime = DateTimeHelper.ConvertStringToTime(dto.startstr, TimeFormats.HH_MM_AM);
                }
                if (!String.IsNullOrEmpty(dto.endstr))
                {
                    dto.EndActiveTime = DateTimeHelper.ConvertStringToTime(dto.endstr, TimeFormats.HH_MM_AM);
                }

                dto.outDays = outdays1 + " " + outdays2 + " " + outdays3 + " " + outdays4 + " " + outdays5 + " " + outdays6 + " " + outdays7;
                if (String.IsNullOrEmpty(outdays1) && String.IsNullOrEmpty(outdays2) && String.IsNullOrEmpty(outdays3) && String.IsNullOrEmpty(outdays4) && String.IsNullOrEmpty(outdays5) && String.IsNullOrEmpty(outdays6) && String.IsNullOrEmpty(outdays7))
                {
                    dto.outDays = null;
                }
                _BranchAndShopDalservice.Edit(dto);
                return RedirectToAction("addBranchAndShopDal", "BranchAndShopDal");

            }
            return View(dto);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllBranchAndShopDal()
        {

         return View(_BranchAndShopDalservice.getAllBranchAndShopDal().OrderByDescending(x => x.Id));
        }
        [Authorize(Roles = "Admin")]
        public JsonResult getConvinientsubCatSub(int sid)
        {
            var data = Selects.subcatDalByMainCatDal(null, sid);
            return Json(data);
        }
        [Authorize(Roles = "Admin")]
        public JsonResult getConvinientRegions(int sid)
        {
            var data = Selects.regionsByState(null, sid);
            return Json(data);
        }
        [Authorize(Roles = "Admin")]
        public JsonResult getConvinientNeiberHood(int sid)
        {
            var data = Selects.NeiberHoodByregion(null, sid);
            return Json(data);
        }
    }
}