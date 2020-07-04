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
    public class MainCategoryOffersController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IMainCategoryOffersService _mainofferService;
        public MainCategoryOffersController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice,IMainCategoryOffersService mainofferService)
            :base(userManager,aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._mainofferService = mainofferService;
        }
        [Authorize(Roles = "Admin")]
        [RuleSetForClientSideMessages("AddM")]
        public ActionResult AddmaincatOffer()
        {
            return View();
        }
        [RuleSetForClientSideMessages("AddM")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddmaincatOffer([CustomizeValidator(RuleSet = "AddM")]MainCategoryOffersDto dto)
        {
            int i = _mainofferService.addMainCategoryOffers(dto);
            return RedirectToAction("AddmaincatOffer");
        }
        [Authorize(Roles = "Admin")]
    
        public ActionResult getAllmaincatOffer()
        {

            return View(_mainofferService.getMainCategoryOffers().OrderBy(x => x.num));
        }

        [Authorize(Roles = "Admin")]
  
        public ActionResult deletemaincatOffer(int id)
        {
            var x = _mainofferService.deleteMainCategoryOffers(id);
            if (x)
                return RedirectToAction("AddmaincatOffer");
            return RedirectToAction("Error","Account");
        }
        [Authorize(Roles = "Admin")]
        [RuleSetForClientSideMessages("EditM")]
        public ActionResult Edit(int id)
        {

            var dto = _mainofferService.GetById(id);
            return View(dto);
        }
        [RuleSetForClientSideMessages("EditM")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([CustomizeValidator(RuleSet = "EditM")]MainCategoryOffersDto mainCategoryOfferdto)
        {

            if (ModelState.IsValid)
            {

                _mainofferService.Edit(mainCategoryOfferdto);
                return RedirectToAction("AddmaincatOffer", "MainCategoryOffers");

            }
            return View(mainCategoryOfferdto);
        }



    }
}