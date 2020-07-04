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
    public class BreakeController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IRegionService _regionservice;
        IBranchService _branchService;
        IShopDalService _shopDalService;
        INotificationService _INotificationService;
        IBreakService _BreakService;
        IGalleryPhotoService _GalleryPhotoService;
        public BreakeController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, IRegionService regionservice, INotificationService ins, IBranchService branchService, IShopDalService shopDalService, IBreakService BreakService, IGalleryPhotoService GalleryPhotoService)
            : base(userManager, aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._regionservice = regionservice;
            this._branchService = branchService;
            this._shopDalService = shopDalService;
            this._INotificationService = ins;
            this._BreakService = BreakService;
            this._GalleryPhotoService = GalleryPhotoService;
        }
        [Authorize(Roles = "Admin")]

        public ActionResult AddBreak(int? bid)
        {
            if (bid == null)
            {
                return RedirectToAction("Search");
            }
            ViewBag.bid = bid;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddBreak(BreakDto dto,int?bid)
        {
            dto.BranchId = bid.GetValueOrDefault();
            if (dto.sstr != null)
            {
                dto.start = DateTimeHelper.ConvertStringToTime(dto.sstr, TimeFormats.HH_MM_AM);
            }
            if (dto.estr != null)
            {
                dto.end = DateTimeHelper.ConvertStringToTime(dto.estr, TimeFormats.HH_MM_AM);
            }
            int i = _BreakService.addBreak(dto);

            return RedirectToAction("AddBreak", new { bid = bid });
        }
     

        [Authorize(Roles = "Admin")]
        public ActionResult Search()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllBranchFiltere(FilterGalleryPhotoDto filter, string bname)
        {
            
            filter.branchId = Convert.ToInt32(bname);
            if (Request.IsAjaxRequest())
            {

                return View(_GalleryPhotoService.getAllBranchfilter(filter));
            }
            return View(_GalleryPhotoService.getAllBranchfilter(filter));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult getBreakForBranch(int? bid, string bname)
        {
            ViewBag.bname = bname;

            return View(_BreakService.getAllBreakbyBranch(bid.GetValueOrDefault()));
        }

        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int? id, int? bid)
        {

            var dto = _BreakService.GetById(id.GetValueOrDefault());
            dto.sstr = DateTimeHelper.ConvertTimeToString(dto.start, TimeFormats.HH_MM_AM);
            dto.estr = DateTimeHelper.ConvertTimeToString(dto.end, TimeFormats.HH_MM_AM);
            ViewBag.bid = bid;
            return View(dto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BreakDto dto, int? id, int? bid)
        {

            dto.BranchId = Convert.ToInt32(bid);
            dto.BranchId = bid.GetValueOrDefault();

            if (dto.sstr != null)
            {
                dto.start = DateTimeHelper.ConvertStringToTime(dto.sstr, TimeFormats.HH_MM_AM);
            }
            if (dto.estr != null)
            {
                dto.end = DateTimeHelper.ConvertStringToTime(dto.estr, TimeFormats.HH_MM_AM);
            }

            _BreakService.Edit(dto, id.GetValueOrDefault());
            return RedirectToAction("AddBreak", new { bid = bid });



        }
        public ActionResult deleteBreake(int? id, int? bid)
        {
            var x = _BreakService.deleteBreak(id.GetValueOrDefault());
            if (x)
                return RedirectToAction("AddBreak", new { bid = bid });
            return RedirectToAction("Error","Account");
        }
    }
}