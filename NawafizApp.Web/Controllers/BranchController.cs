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
    public class BranchController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IRegionService _regionservice;
        IBranchService _branchService;
        IShopDalService _shopDalService;
        public BranchController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, IRegionService regionservice, IBranchService branchService, IShopDalService shopDalService)
            : base(userManager, aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._regionservice = regionservice;
            this._branchService = branchService;
            this._shopDalService = shopDalService;
        }
       
        [Authorize(Roles = "Admin")]
        public ActionResult addBranch(int? shopid)
        {
            if (shopid==null)
            {
                return RedirectToAction("Search");
            }
            ViewBag.shid = shopid;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult addBranch(int? shopid, BranchDto dto, string outdays1, string outdays2, string outdays3, string outdays4, string outdays5, string outdays6, string outdays7)
        {
            //dto.ShopDalId = shopid;
            if (!String.IsNullOrEmpty(dto.sstr))
            {
                dto.StartActiveTime = DateTimeHelper.ConvertStringToTime(dto.sstr, TimeFormats.HH_MM_AM);
            }
            if (!String.IsNullOrEmpty(dto.estr))
            {
                dto.EndActiveTime = DateTimeHelper.ConvertStringToTime(dto.estr, TimeFormats.HH_MM_AM);
            }

            dto.outDays = outdays1 + " " + outdays2 + " " + outdays3 + " " + outdays4 + " " + outdays5 + " " + outdays6 + " " + outdays7;
            if (String.IsNullOrEmpty(outdays1) && String.IsNullOrEmpty(outdays2) && String.IsNullOrEmpty(outdays3) && String.IsNullOrEmpty(outdays4) && String.IsNullOrEmpty(outdays5) && String.IsNullOrEmpty(outdays6) && String.IsNullOrEmpty(outdays7))
            {
                dto.outDays = null;
            }

            var x = _branchService.addBranch(dto);

            return RedirectToAction("addBranch", new { shopid = shopid });
        }

      
        [Authorize(Roles = "Admin")]
        public ActionResult deleteBranch(int id, int? shopId)
        {
            var x = _branchService.deleteBranch(id);
            if (x)
                return RedirectToAction("addBranch", new { shopid = shopId });
            return RedirectToAction("Error","Account");
        }
      
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, int? shopid)
        {
            ViewBag.shid = shopid;
            
            var dto = _branchService.GetById(id);
           
            ViewBag.regionid = dto.RegionId.ToString(); ;
            ViewBag.regionname = dto.RegionName;
            ViewBag.neiborid = dto.NeighborhoodId.ToString();
            ViewBag.neiborname = dto.NeighborhoodName;
            //dto.sstr = DateTimeHelper.ConvertTimeToString(dto.StartActiveTime, TimeFormats.HH_MM_AM);
            //dto.estr = DateTimeHelper.ConvertTimeToString(dto.EndActiveTime, TimeFormats.HH_MM_AM);
            //dto.stateId = _branchService.GetById(id).stateId;
            ////dto.RegionId = _branchService.GetById(id).RegionId;
            ////dto.NeighborhoodId = _branchService.GetById(id).NeighborhoodId;

            return View(dto);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? shopid,BranchDto dto, string outdays1, string outdays2, string outdays3, string outdays4, string outdays5, string outdays6, string outdays7)
        {
            if (!String.IsNullOrEmpty(dto.sstr))
            {
                dto.StartActiveTime = DateTimeHelper.ConvertStringToTime(dto.sstr, TimeFormats.HH_MM_AM);
            }
            if (!String.IsNullOrEmpty(dto.estr))
            {
                dto.EndActiveTime = DateTimeHelper.ConvertStringToTime(dto.estr, TimeFormats.HH_MM_AM);
            }

            dto.outDays = outdays1 + " " + outdays2 + " " + outdays3 + " " + outdays4 + " " + outdays5 + " " + outdays6 + " " + outdays7;
            if (String.IsNullOrEmpty(outdays1) && String.IsNullOrEmpty(outdays2) && String.IsNullOrEmpty(outdays3) && String.IsNullOrEmpty(outdays4) && String.IsNullOrEmpty(outdays5) && String.IsNullOrEmpty(outdays6) && String.IsNullOrEmpty(outdays7))
            {
                dto.outDays = null;
            }
            dto.ShopDalId = shopid;
            _branchService.Edit(dto);
            return RedirectToAction("addBranch", new { shopid = shopid });
        }
       
        [Authorize(Roles = "Admin")]
        public ActionResult Search()
        {
            ViewBag.shopdals = _shopDalService.getAllShopDal().ToList();
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllShopDalResult(FilterDto filter ,string shopDalName)
        {
            filter.shopDalName = shopDalName;
            if (Request.IsAjaxRequest())
            {
                return View(_shopDalService.getAllShopDalfilter(filter));
            }
            return View(_shopDalService.getAllShopDalfilter(filter));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllBranchByShopDal(int? shopId)
        {
            return View(_branchService.getAllBranchbyShopdalid(shopId).OrderByDescending(x => x.Id));
        }
    }
}