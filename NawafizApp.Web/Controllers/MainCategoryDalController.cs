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
    public class MainCategoryDalController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        IMainCategoryDalService _maincategoryDalservice;
        public MainCategoryDalController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, IMainCategoryDalService maincategoryDalservice)
            :base(userManager,aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._maincategoryDalservice = maincategoryDalservice;
        }

        [Authorize(Roles = "Admin")]
        [RuleSetForClientSideMessages("Add")]
        public ActionResult addMainCategoryDal()
        {
            return View();

        }
        [RuleSetForClientSideMessages("Add")]
        [HttpPost]
        [Authorize(Roles = "Admin")]   
        [ValidateAntiForgeryToken]
        public ActionResult addMainCategoryDal([CustomizeValidator(RuleSet ="Add")] MainCategoryDalDto dto, HttpPostedFileBase file, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            List<HttpPostedFileBase> list = new List<HttpPostedFileBase>();
            list.Add(file);
            list.Add(file1);
            list.Add(file2);
            list.Add(file3);
            list.Add(file4);
            foreach (var item in list)
            {
                if (item != null)
                {
                    if (item.ContentLength > ( 4*1024 * 1024))
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
            if (file!=null)
            {
                dto.icon = new byte[file.ContentLength];
                file.InputStream.Read(dto.icon, 0, file.ContentLength);
            }
            if (file1 != null)
            {
                dto.iconEn = new byte[file1.ContentLength];
                file1.InputStream.Read(dto.iconEn, 0, file1.ContentLength);
            }
            if (file2 != null)
            {
                dto.iconFr = new byte[file2.ContentLength];
                file2.InputStream.Read(dto.iconFr, 0, file2.ContentLength);
            }
            if (file3 != null)
            {
                dto.iconPersian = new byte[file3.ContentLength];
                file3.InputStream.Read(dto.iconPersian, 0, file3.ContentLength);
            }
            if (file4 != null)
            {
                dto.iconRuss = new byte[file4.ContentLength];
                file4.InputStream.Read(dto.iconRuss, 0, file4.ContentLength);
            }
           
            int x = _maincategoryDalservice.addMainCategoryDal(dto);
            return RedirectToAction("addMainCategoryDal");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllMainCategoriesDal(int? MainCategoryDal=-100)
        {

            if (Request.IsAjaxRequest())
            {
                if (MainCategoryDal != -100)
                {
                    return PartialView(_maincategoryDalservice.getMainCategoryDal().OrderBy(x => x.num).Where(x => x.Id == MainCategoryDal.Value).OrderBy(x => x.ArabicName));
                }
                else
                {
                    return PartialView(_maincategoryDalservice.getMainCategoryDal().OrderBy(x => x.num));
                }
            }
            return View(_maincategoryDalservice.getMainCategoryDal().OrderBy(x => x.num));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getMainCategoryDalfullSize(int id)
        {
            if (id == -1000) { return RedirectToAction("addMainCategoryDal"); }
            return View(_maincategoryDalservice.getMainCategoryDalForFullSize(id));

        }
        [Authorize(Roles = "Admin")]
        public ActionResult deleteMainCategoryDal(int id)
        {
            var x = _maincategoryDalservice.deleteMainCategoryDal(id);
            if (x)
                return RedirectToAction("addMainCategoryDal");
            return RedirectToAction("Error");
        }
        [Authorize(Roles = "Admin")]
        [RuleSetForClientSideMessages("Edit")]
        public ActionResult EditMainCategoryDal(int id)
        {

            var dto = _maincategoryDalservice.GetById(id);
            return View(dto);
        }
        [RuleSetForClientSideMessages("Edit")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditMainCategoryDal([CustomizeValidator(RuleSet = "Edit")] MainCategoryDalDto dto, HttpPostedFileBase file, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            List<HttpPostedFileBase> list = new List<HttpPostedFileBase>();
            list.Add(file);
            list.Add(file1);
            list.Add(file2);
            list.Add(file3);
            list.Add(file4);

          
               
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
                    dto.icon = new byte[file.ContentLength];
                    file.InputStream.Read(dto.icon, 0, file.ContentLength);
                }
                if (file1 != null)
                {
                    dto.iconEn = new byte[file1.ContentLength];
                    file1.InputStream.Read(dto.iconEn, 0, file1.ContentLength);
                }
                if (file2 != null)
                {
                    dto.iconFr = new byte[file2.ContentLength];
                    file2.InputStream.Read(dto.iconFr, 0, file2.ContentLength);
                }
                if (file3 != null)
                {
                    dto.iconPersian = new byte[file3.ContentLength];
                    file3.InputStream.Read(dto.iconPersian, 0, file3.ContentLength);
                }
                if (file4 != null)
                {
                    dto.iconRuss = new byte[file4.ContentLength];
                    file4.InputStream.Read(dto.iconRuss, 0, file4.ContentLength);
                }
                _maincategoryDalservice.Edit(dto);
                return RedirectToAction("addMainCategoryDal", "MainCategoryDal");

            }
     
        

    }
}