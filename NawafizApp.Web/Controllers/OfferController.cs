using NawafizApp.Common;
using NawafizApp.Common;
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
    public class OfferController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IOfferService _offerservice;
        INeihborhoodService _neihborhoodservice;
        ISubCategetoryOffersService _SubCategetoryOffeservice;
        public OfferController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, IOfferService offerservice, INeihborhoodService neiborhoodservice, ISubCategetoryOffersService SubCategetoryOffeservice)
            :base(userManager,aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._offerservice = offerservice;
            this._neihborhoodservice = neiborhoodservice;
            this._SubCategetoryOffeservice = SubCategetoryOffeservice;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult addOffer()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult addOffer(OfferDto dto, HttpPostedFileBase file, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, DateTime start, DateTime end)
        {
            List<HttpPostedFileBase> list = new List<HttpPostedFileBase>();
            list.Add(file);
            list.Add(file1);
            list.Add(file2);
            list.Add(file3);


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
            }
            if (file != null)
            {
                dto.photo = new byte[file.ContentLength];
                file.InputStream.Read(dto.photo, 0, file.ContentLength);
            }
            if (file1 != null)
            {
                dto.photo1 = new byte[file1.ContentLength];
                file1.InputStream.Read(dto.photo1, 0, file1.ContentLength);
            }
            if (file2 != null)
            {
                dto.photo2 = new byte[file2.ContentLength];
                file2.InputStream.Read(dto.photo2, 0, file2.ContentLength);
            }
            if (file3 != null)
            {
                dto.photo3 = new byte[file3.ContentLength];
                file3.InputStream.Read(dto.photo3, 0, file3.ContentLength);
            }
            dto.Dateofpuplishing = Utils.ServerNow.Date;
            dto.Timeofpuplishing = Utils.ServerNow.TimeOfDay;
            if (dto.Start != null)
            {
                dto.Start = start;
            }
            if (dto.end != null)
            {
                dto.end = end;
            }
            int x = _offerservice.addOffer(dto);
            return RedirectToAction("addOffer");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult deleteoffer(int id)
        {
            var x = _offerservice.deleteOffer(id);
            if (x)
                return RedirectToAction("addOffer");
            return RedirectToAction("Error");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edite(int id,int mid,int subid/*, DateTime Start, DateTime end*/)
        {
            var i = _offerservice.GetById(id);
            //Start = i.Start;
            //end = i.end;               
            i.MainCategetoryOffersId = _offerservice.getAllOffers().Find(x => x.Id==id).MainCategetoryOffersId;
            i.SubCategetoryOffersId = subid;
            ViewBag.sid = _offerservice.getAllOffers().Find(x => x.Id == id).SubCategetoryOffersId.ToString();
            ViewBag.sname = _offerservice.getAllOffers().Find(x => x.Id == id).SubCategetoryOffersName;
            var xxx = _offerservice.getAllOffers().Find(x => x.Id == id).Start;           
            i.startstr = DateTimeHelper.ConvertDateToString(xxx,DateFormats.DD_MM_YYYY);
           var xx = _offerservice.getAllOffers().Find(x => x.Id == id).end;
            i.endtstr = DateTimeHelper.ConvertDateToString(xx, DateFormats.DD_MM_YYYY);
            return View(i);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edite(OfferDto dto, HttpPostedFileBase file, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, DateTime Start, DateTime end)
        {
            if (ModelState.IsValid)
            {
                List<HttpPostedFileBase> list = new List<HttpPostedFileBase>();
                list.Add(file);
                list.Add(file1);
                list.Add(file2);
                list.Add(file3);
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
                }
                if (file != null)
                {
                    dto.photo = new byte[file.ContentLength];
                    file.InputStream.Read(dto.photo, 0, file.ContentLength);
                }
                if (file1 != null)
                {
                    dto.photo1 = new byte[file1.ContentLength];
                    file1.InputStream.Read(dto.photo1, 0, file1.ContentLength);
                }
                if (file2 != null)
                {
                    dto.photo2 = new byte[file2.ContentLength];
                    file2.InputStream.Read(dto.photo2, 0, file2.ContentLength);
                }
                if (file3 != null)
                {
                    dto.photo3 = new byte[file3.ContentLength];
                    file3.InputStream.Read(dto.photo3, 0, file3.ContentLength);
                }

                if (dto.Start== null)
                {
                    dto.Start = Start;
                }
              
                if (dto.end == null)
                {
                    dto.end = end;
                }
              
               
               
                _offerservice.Edit(dto);
                return RedirectToAction("addOffer", "Offer");

            }
            return View(dto);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllOffer(int? mainId = -100, int? subId = -100)
        {
            if (Request.IsAjaxRequest())
            {
                if (mainId != -100 && subId == -100)
                {
                    return PartialView(_offerservice.getAllOffers().OrderByDescending(x => x.Id).Where(x => x.MainCategetoryOffersId == mainId.Value).OrderBy(x => x.SubCategetoryOffersName).OrderBy(x => x.MainCategetoryOffersName));
                }
                if (mainId != -100 && subId != -100)
                {
                    return PartialView(_offerservice.getAllOffers().OrderByDescending(x => x.Id).Where(x => x.MainCategetoryOffersId == mainId.Value && x.SubCategetoryOffersId == subId.Value).OrderBy(x => x.SubCategetoryOffersName).OrderBy(x => x.MainCategetoryOffersName));
                }
            }
            return View(_offerservice.getAllOffers().OrderByDescending(x => x.Id).OrderBy(x => x.SubCategetoryOffersName).OrderBy(x => x.MainCategetoryOffersName));
        }
        [Authorize(Roles = "Admin")]
        public JsonResult getConvinientsubCat(int sid)
        {
            var data = Selects.subcatByMainCat(null, sid);
            return Json(data);
        }
        [Authorize(Roles = "Admin")]
        public JsonResult getConvinientsubCatForInitial(int sid)
        {
            var data = Selects.subcatByMainCatForInitial(null, sid);
            return Json(data);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getofferfullSize(int id= -1000)
        {
            if (id == -1000) { return RedirectToAction("addOffer"); }
            return View(_offerservice.getofferForFullSize(id));

        }
        public ActionResult getofferfullSizeforDetal(int id = -1000)
        {
            if (id == -1000) { return RedirectToAction("addOffer"); }
            return View(_offerservice.getofferForFullSize(id));

        }
    }
}