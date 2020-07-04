using FluentValidation.Mvc;
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
    public class SubCategetoryOffersController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        ISubCategetoryOffersService _SubCategoryOfferservice;
        public SubCategetoryOffersController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, ISubCategetoryOffersService SubCategoryofferservice)
            :base(userManager,aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._SubCategoryOfferservice = SubCategoryofferservice;
        }
        [Authorize(Roles = "Admin")]
        [RuleSetForClientSideMessages("AddS")]
        public ActionResult addSubCategetoryOffer()
        {
            return View();
        }

        [RuleSetForClientSideMessages("AddS")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult addSubCategetoryOffer([CustomizeValidator(RuleSet = "AddS")]SubCategetoryOffersDto dto)
        {

            var i = _SubCategoryOfferservice.addSubCategetoryOffers(dto);
            return RedirectToAction("addSubCategetoryOffer");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult deleteSubCategetoryOffer(int id)
        {
            var x = _SubCategoryOfferservice.deleteSubCategetoryOffers(id);
            if (x)
                return RedirectToAction("addSubCategetoryOffer");
            return RedirectToAction("Error");
        }
        [Authorize(Roles = "Admin")]
        [RuleSetForClientSideMessages("EditS")]
        public ActionResult Edite(int id)
        {
            var i = _SubCategoryOfferservice.GetById(id);
            return View(i);
        }

        [RuleSetForClientSideMessages("EditS")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edite([CustomizeValidator(RuleSet = "EditS")]SubCategetoryOffersDto dto)
        {
            if (ModelState.IsValid)
            {

                _SubCategoryOfferservice.Edit(dto);
                return RedirectToAction("addSubCategetoryOffer", "SubCategetoryOffers");

            }
            return View(dto);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllSubCategoryOffer(int? MainCategoryDal = -100)
        {

            if (Request.IsAjaxRequest())
            {
                if (MainCategoryDal != -100)
                {
                    return PartialView(_SubCategoryOfferservice.getAllSubCategetoryOffers().OrderBy(x => x.num).Where(x => x.MainCategoryOffersId == MainCategoryDal.Value).OrderBy(x => x.ArabicName));
                }
                else
                {
                    return PartialView(_SubCategoryOfferservice.getAllSubCategetoryOffers().OrderBy(x => x.num));
                }
            }
            return View(_SubCategoryOfferservice.getAllSubCategetoryOffers().OrderBy(x => x.num));
        }



    }
}