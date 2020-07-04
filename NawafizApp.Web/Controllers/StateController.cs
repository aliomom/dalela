using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NawafizApp.Services.Dtos;
using NawafizApp.Web.Models;
using System.Web.Mvc;
namespace NawafizApp.Web.Controllers
{
    public class StateController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        public StateController(ApplicationUserManager userManager, ApplicationSignInManager aps,  IUserService IUS,IStateService stateservice)
            :base(userManager,aps)
        {
           
            this._userService = IUS;
            this._stateservice = stateservice;
        }
        [Authorize(Roles ="Admin")]
     
        public ActionResult AddState() {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddState(StateDto dto)
        {
            int i = _stateservice.Add(dto);
            return RedirectToAction("AddState");
        }
        [Authorize(Roles = "Admin")]
      
        public ActionResult getAllStates()
        {
           
            return View(_stateservice.All().OrderByDescending(x => x.Id));
        }
        [Authorize(Roles = "Admin")]
  
        public ActionResult deleteState(int id)
        {
            var x = _stateservice.RemoveState(id);
            if (x)
                return RedirectToAction("AddState");
            return RedirectToAction("Error");
        }
        [Authorize(Roles = "Admin")]
 
        public ActionResult Edit(int id)
        {
          
            var dto = _stateservice.GetById(id);
            return View(dto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StateDto stateDto)
        {

            if (ModelState.IsValid)
            {
              
                _stateservice.Edit(stateDto);
                return RedirectToAction("AddState", "State");

            }
            return View(stateDto);
        }
    }
}