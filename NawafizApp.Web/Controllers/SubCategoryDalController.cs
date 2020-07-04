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
    public class SubCategoryDalController : BaseAuthorizeController
    {
        IUserService _userService;
        IStateService _stateservice;
        ISubCategoryDalService _SubCategoryDalservice;
        public SubCategoryDalController(ApplicationUserManager userManager, ApplicationSignInManager aps, IUserService IUS, IStateService stateservice, ISubCategoryDalService SubCategoryDalservice)
            :base(userManager,aps)
        {

            this._userService = IUS;
            this._stateservice = stateservice;
            this._SubCategoryDalservice = SubCategoryDalservice;
        }

        [Authorize(Roles = "Admin")]
    
        public ActionResult addSubCategoryDal()
        {
            return View();

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult addSubCategoryDal(SubCategoryDalDto dto, HttpPostedFileBase file, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
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
                    if (item.ContentLength > (4*1024 * 1024))
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
            int x = _SubCategoryDalservice.addSubCategoryDal(dto);
            return RedirectToAction("addSubCategoryDal");

        }
        [Authorize(Roles = "Admin")]
       
        public ActionResult getAllSubCategoryDal(int? MainCategoryDal = -100)
        {

            if (Request.IsAjaxRequest())
            {
                if (MainCategoryDal != -100)
                {
                    return PartialView(_SubCategoryDalservice.getAllSubCategoriesDal().OrderByDescending(x => x.Id).Where(x => x.MainCategoryDalId == MainCategoryDal.Value).OrderBy(x => x.ArabicName));
                }
                else
                {
                    return PartialView(_SubCategoryDalservice.getAllSubCategoriesDal().OrderByDescending(x => x.Id));
                }
            }
            return View(_SubCategoryDalservice.getAllSubCategoriesDal().OrderByDescending(x => x.Id));
        }

        [Authorize(Roles = "Admin")]
        
        public ActionResult deleteSubCategoryDal(int id)
        {
            var x = _SubCategoryDalservice.deleteSubCategoryDal(id);
            if (x)
                return RedirectToAction("addSubCategoryDal");
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        
        public ActionResult EditSubCategoryDal(int id)
        {

            var dto = _SubCategoryDalservice.GetById(id);
            return View(dto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubCategoryDal(SubCategoryDalDto dto, HttpPostedFileBase file, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
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
                _SubCategoryDalservice.Edit(dto);
                return RedirectToAction("addSubCategoryDal", "SubCategoryDal");

            
            return View(dto);
        }
        [Authorize(Roles = "Admin")]
       
        public ActionResult getSubCategoryDalfullSize(int id)
        {
            if (id == -1000) { return RedirectToAction("addSubCategoryDal"); }
            return View(_SubCategoryDalservice.getSubCategoryDalForFullSize(id));

        }

    }
}