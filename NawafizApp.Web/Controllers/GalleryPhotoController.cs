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
    public class GalleryPhotoController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IRegionService _regionservice;
        IBranchService _branchService;
        IShopDalService _shopDalService;
        INotificationService _INotificationService;
        IGalleryPhotoService _GalleryPhotoService;
        public GalleryPhotoController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, IRegionService regionservice, INotificationService ins, IBranchService branchService, IShopDalService shopDalService,IGalleryPhotoService GalleryPhotoService)
            : base(userManager, aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._regionservice = regionservice;
            this._branchService = branchService;
            this._shopDalService = shopDalService;
            this._INotificationService = ins;
            this._GalleryPhotoService = GalleryPhotoService;
        }

        [Authorize(Roles = "Admin")]

        public ActionResult AddGalleryPhoto(int? bid)
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
        public ActionResult AddGalleryPhoto(int? bid,GalleryPhotoDto dto, HttpPostedFileBase file)
        {
            List<HttpPostedFileBase> list = new List<HttpPostedFileBase>();
            list.Add(file);
            foreach (var item in list)
            {
                if (item != null)
                {
                    if (item.ContentLength > (4 * 1024 * 1024))
                    {
                        ModelState.AddModelError("CustomError", "file size must be less than 4MB");
                        return View();
                    }
                    if (!(item.ContentType == "image/jpeg" || item.ContentType == "image/png" || item.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("CustomError", "الأنماط المسموحة :jpeg , png , gif");
                        return View();
                    }


                }
                if (file != null)
                {
                    dto.photo = new byte[file.ContentLength];
                    file.InputStream.Read(dto.photo, 0, file.ContentLength);
                }
            }
            dto.BranchId = bid.GetValueOrDefault();
            int i = _GalleryPhotoService.addGalleryPhotoDto(dto);
            return RedirectToAction("AddGalleryPhoto",new { bid=bid});
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Search()
        {
          
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllBranchFilter(FilterGalleryPhotoDto filter,string bname)
        {
            filter.branchId =Convert.ToInt32(bname);
            if (Request.IsAjaxRequest())
            {
 
                return View(_GalleryPhotoService.getAllBranchfilter(filter));
            }
            return View(_GalleryPhotoService.getAllBranchfilter(filter));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult getGalleryPhotoForBranch( int? bid,string bname)
        {
            ViewBag.bname = bname;
        
            return View(_GalleryPhotoService.GetGalleryPhotoDtoforBanch(bid.GetValueOrDefault()));
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int? id,int?bid)
        {

            var dto = _stateservice.GetById(id.GetValueOrDefault());
            ViewBag.bid = bid;
            return View(dto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GalleryPhotoDto dto,int? id,int? bid,string bname, HttpPostedFileBase file)
        {
        
            dto.BranchId = Convert.ToInt32(bid);
            List<HttpPostedFileBase> list = new List<HttpPostedFileBase>();
            list.Add(file);
            foreach (var item in list)
            {
                if (item != null)
                {
                    if (item.ContentLength > (4 * 1024 * 1024))
                    {
                        ModelState.AddModelError("CustomError", "file size must be less than 4MB");
                        return View();
                    }
                    if (!(item.ContentType == "image/jpeg" || item.ContentType == "image/png" || item.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("CustomError", "الأنماط المسموحة :jpeg , png , gif");
                        return View();
                    }


                }
                if (file != null)
                {
                    dto.photo = new byte[file.ContentLength];
                    file.InputStream.Read(dto.photo, 0, file.ContentLength);
                }
            }
            
                _GalleryPhotoService.EditbyId(dto,id.GetValueOrDefault());
                return RedirectToAction("getGalleryPhotoForBranch",new { bid=bid,bname=bname});

            
            
        }
        [Authorize(Roles = "Admin")]

        public ActionResult deleteFromGalleryPhoto(int? id, int? bid, string bname)
        {
            var x = _GalleryPhotoService.deleteGalleryPhotoDto(id.GetValueOrDefault());
            if (x)
                return RedirectToAction("getGalleryPhotoForBranch", new { bid = bid, bname = bname });
            return RedirectToAction("Account");
        }
    }
}