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
    public class FollowerController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IRegionService _regionservice;
        IBranchService _branchService;
        IShopDalService _shopDalService;
        INotificationService _INotificationService;
        IFollowerService _FollowerService;
        public FollowerController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, IRegionService regionservice, INotificationService ins, IBranchService branchService, IShopDalService shopDalService, IFollowerService FollowerService)
            : base(userManager, aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._regionservice = regionservice;
            this._branchService = branchService;
            this._shopDalService = shopDalService;
            this._INotificationService = ins;
            this._FollowerService = FollowerService;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Search()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllFollwer(Guid? UserId)
        {
            if (Request.IsAjaxRequest())
            {
                if (UserId!=null)
                {
                    return View(_FollowerService.getAllFollowers().Where(x => x.UserId == UserId));
                }
             
             
                if (UserId == null )
                {
                    return View(_FollowerService.getAllFollowers());
                }
            }
            return View(_FollowerService.getAllFollowers());

        }
      
    }
}