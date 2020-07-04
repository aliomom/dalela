using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;
using NawafizApp.Domain;
using NawafizApp.Common;
using NawafizApp.Domain.Entities;
using NawafizApp.Common;

namespace NawafizApp.Services.Services
{
    public class ArabicServiceAPI : IArabicServiceAPI
    {

        private readonly IUnitOfWork _unitOfWork;
        public ArabicServiceAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public List<APIMainCategoryDtoAr> getAllArabicMainCategories(string slug)
        {

            var list = _unitOfWork.MainCategoryDalRepository.GetAll();
            APIMainCategoryDtoAr dto = new APIMainCategoryDtoAr();
            List<APIMainCategoryDtoAr> res = new List<APIMainCategoryDtoAr>();
            if (slug == "ar")
            {
                foreach (var item in list)
                {
                    dto.MainCatId = item.Id;
                    dto.Name = item.ArabicName;
                    if (item.icon != null)
                        dto.icon = Convert.ToBase64String(item.icon);
                    res.Add(dto);
                    dto = new APIMainCategoryDtoAr();
                }
            }
            if (slug == "en")
            {
                foreach (var item in list)
                {
                    dto.MainCatId = item.Id;
                    dto.Name = item.EngName;
                    if (item.icon != null)
                        dto.icon = Convert.ToBase64String(item.iconEn);
                    res.Add(dto);
                    dto = new APIMainCategoryDtoAr();
                }
            }
            if (slug == "fr")
            {
                foreach (var item in list)
                {
                    dto.MainCatId = item.Id;
                    dto.Name = item.FrenchName;
                    if (item.icon != null)
                        dto.icon = Convert.ToBase64String(item.iconFr);
                    res.Add(dto);
                    dto = new APIMainCategoryDtoAr();
                }
            }
            if (slug == "ru")
            {
                foreach (var item in list)
                {
                    dto.MainCatId = item.Id;
                    dto.Name = item.RussName;
                    if (item.icon != null)
                        dto.icon = Convert.ToBase64String(item.iconRuss);
                    res.Add(dto);
                    dto = new APIMainCategoryDtoAr();
                }
            }
            if (slug == "pr")
            {
                foreach (var item in list)
                {
                    dto.MainCatId = item.Id;
                    dto.Name = item.PersianName;
                    if (item.icon != null)
                        dto.icon = Convert.ToBase64String(item.iconPersian);
                    res.Add(dto);
                    dto = new APIMainCategoryDtoAr();
                }
            }
            return res;
        }
        public List<APIShopsDisplayDtoAr> getShopsBySubCat(int SubCatId, int? stateId, int? regionId,string slug)
        {
            APIShopsDisplayDtoAr dto = new APIShopsDisplayDtoAr();
            var list = new List<Branch>();
            if (stateId.HasValue && regionId.HasValue)
            {
                list = _unitOfWork.BranchRepository.GetAll().Where(x => x.ShopDal.SubCategoryDalId == SubCatId && x.Neighborhood.RegionId == regionId.Value && x.Neighborhood.Region.StateId == stateId.Value).ToList();
            }
            else if (stateId.HasValue && !regionId.HasValue)
            {
                list = _unitOfWork.BranchRepository.GetAll().Where(x => x.ShopDal.SubCategoryDalId == SubCatId && x.Neighborhood.Region.StateId == stateId.Value).ToList();
            }
            else
            {
                list = _unitOfWork.BranchRepository.GetAll().Where(x => x.ShopDal.SubCategoryDalId == SubCatId).ToList();
            }
            List<APIShopsDisplayDtoAr> res = new List<APIShopsDisplayDtoAr>();
            if (slug == "ar")
            {
                foreach (var item in list)
                {
                    dto.Name = item.branchArabicName;
                    dto.shopId = item.Id;
                    res.Add(dto);
                    dto = new APIShopsDisplayDtoAr();
                }
            }
            if (slug == "en")
            {
                foreach (var item in list)
                {
                    dto.Name = item.branchEnglishName;
                    dto.shopId = item.Id;
                    res.Add(dto);
                    dto = new APIShopsDisplayDtoAr();
                }
            }
            if (slug == "fr")
            {
                foreach (var item in list)
                {
                    dto.Name = item.branchFrenchName;
                    dto.shopId = item.Id;
                    res.Add(dto);
                    dto = new APIShopsDisplayDtoAr();
                }
            }
            if (slug == "ru")
            {
                foreach (var item in list)
                {
                    dto.Name = item.branchRussName;
                    dto.shopId = item.Id;
                    res.Add(dto);
                    dto = new APIShopsDisplayDtoAr();
                }
            }
            if (slug == "pr")
            {
                foreach (var item in list)
                {
                    dto.Name = item.branchPersianName;
                    dto.shopId = item.Id;
                    res.Add(dto);
                    dto = new APIShopsDisplayDtoAr();
                }
            }
            return res;
        }

        public APIShopWithBranchesDtoAr getbranchById(int id,string slug)
        {
           
                var item = _unitOfWork.BranchRepository.FindById(id);
                APIShopWithBranchesDtoAr dto = new APIShopWithBranchesDtoAr();
                APIBranchesForShop br = new APIBranchesForShop();
            if (slug == "ar")
            {

                dto.email1 = item.email1;
                dto.email2 = item.email2;
                dto.hasBarnches = false;
                if (item.ShopDal.Branchs.Count > 1)
                {
                    dto.hasBarnches = true;
                }
                dto.instaLink = item.instaLink;
                dto.latitude = item.latitude;
                dto.longtitude = item.longtitude;
                dto.MainCategoryName = item.ShopDal.SubCategoryDal.MainCategoryDal.ArabicName;
                dto.MainCategoryId = item.ShopDal.SubCategoryDal.MainCategoryDalId;
                dto.EndActiveTime = item.EndActiveTime;
                dto.facebookLink = item.facebookLink;
                dto.NeighborhoodName = item.Neighborhood.ArabicName;
                dto.outDays = item.outDays;
                dto.phone1 = item.phone1;
                dto.phone2 = item.phone2;
                dto.phone3 = item.phone3;
                dto.RegionName = item.Neighborhood.Region.ArabicName;
                dto.ShopName = item.branchArabicName;
                dto.ShopId = item.Id;
                dto.StartActiveTime = item.StartActiveTime;
                dto.stateName = item.Neighborhood.Region.State.ArabicName;
                dto.SubCategoryName = item.ShopDal.SubCategoryDal.ArabicName;
                dto.SubCategoryId = item.ShopDal.SubCategoryDal.Id;

                if (_unitOfWork.BranchRepository.FindBy(x=>x.ShopDalId == item.ShopDalId).Count > 1)
                {
                    dto.Branches = new List<APIBranchesForShop>();
                    foreach (var i in _unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId))
                    {
                        if (i.Id != item.Id)
                        {

                            br.branchName = i.branchArabicName;
                            br.BranchId = i.Id;
                            dto.Branches.Add(br);
                            br = new APIBranchesForShop();
                        }

                    }
                }
                var breaks = _unitOfWork.BreakRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIBreaksForBranchDto ABreak = new APIBreaksForBranchDto();
                dto.breaks = new List<APIBreaksForBranchDto>();
                foreach (var item1 in breaks)
                {
                    ABreak.start = DateTimeHelper.ConvertTimeToString(item1.start, TimeFormats.HH_MM_AM);
                    ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);
                  
                    dto.breaks.Add(ABreak);
                    ABreak = new APIBreaksForBranchDto();

                }
                dto.photos = new List<APIGalleryphotoForBranchDto>();
                var PHOTOS = _unitOfWork.GalleryPhotoRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIGalleryphotoForBranchDto PHO    = new APIGalleryphotoForBranchDto();
                foreach (var item2 in PHOTOS)
                {
                    PHO.photo = Convert.ToBase64String(item2.photo);
                   // ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.photos.Add(PHO);
                    PHO = new APIGalleryphotoForBranchDto();

                }

            }
            if (slug == "en")
            {

                dto.email1 = item.email1;
                dto.email2 = item.email2;
                dto.hasBarnches = false;
                if (item.ShopDal.Branchs.Count > 1)
                {
                    dto.hasBarnches = true;
                }
                dto.instaLink = item.instaLink;
                dto.latitude = item.latitude;
                dto.longtitude = item.longtitude;
                dto.MainCategoryName = item.ShopDal.SubCategoryDal.MainCategoryDal.EngName;
                dto.MainCategoryId = item.ShopDal.SubCategoryDal.MainCategoryDalId;
                dto.EndActiveTime = item.EndActiveTime;
                dto.facebookLink = item.facebookLink;
                dto.NeighborhoodName = item.Neighborhood.EngName;
                dto.outDays = item.outDays;
                dto.phone1 = item.phone1;
                dto.phone2 = item.phone2;
                dto.phone3 = item.phone3;
                dto.RegionName = item.Neighborhood.Region.EngName;
                dto.ShopName = item.branchEnglishName;
                dto.ShopId = item.Id;
                dto.StartActiveTime = item.StartActiveTime;
                dto.stateName = item.Neighborhood.Region.State.EngName;
                dto.SubCategoryName = item.ShopDal.SubCategoryDal.EngName;
                dto.SubCategoryId = item.ShopDal.SubCategoryDal.Id;
                if (_unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId).Count > 1)
                {
                    dto.Branches = new List<APIBranchesForShop>();
                    foreach (var i in _unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId))
                    {
                        if (i.Id != item.Id)
                        {

                            br.branchName = i.branchEnglishName;
                            br.BranchId = i.Id;
                            dto.Branches.Add(br);
                            br = new APIBranchesForShop();
                        }

                    }
                }
                var breaks = _unitOfWork.BreakRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIBreaksForBranchDto ABreak = new APIBreaksForBranchDto();
                foreach (var item1 in breaks)
                {
                    ABreak.start = DateTimeHelper.ConvertTimeToString(item1.start, TimeFormats.HH_MM_AM);
                    ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.breaks.Add(ABreak);
                    ABreak = new APIBreaksForBranchDto();

                }
                var PHOTOS = _unitOfWork.GalleryPhotoRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIGalleryphotoForBranchDto PHO = new APIGalleryphotoForBranchDto();
                foreach (var item2 in PHOTOS)
                {
                    PHO.photo = Convert.ToBase64String(item2.photo);
                    // ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.photos.Add(PHO);
                    PHO = new APIGalleryphotoForBranchDto();

                }

            }
            if (slug == "fr")
            {

                dto.email1 = item.email1;
                dto.email2 = item.email2;
                dto.hasBarnches = false;
                if (item.ShopDal.Branchs.Count > 1)
                {
                    dto.hasBarnches = true;
                }
                dto.instaLink = item.instaLink;
                dto.latitude = item.latitude;
                dto.longtitude = item.longtitude;
                dto.MainCategoryName = item.ShopDal.SubCategoryDal.MainCategoryDal.FrenchName;
                dto.MainCategoryId = item.ShopDal.SubCategoryDal.MainCategoryDalId;
                dto.EndActiveTime = item.EndActiveTime;
                dto.facebookLink = item.facebookLink;
                dto.NeighborhoodName = item.Neighborhood.FrenchName;
                dto.outDays = item.outDays;
                dto.phone1 = item.phone1;
                dto.phone2 = item.phone2;
                dto.phone3 = item.phone3;
                dto.RegionName = item.Neighborhood.Region.FrenchName;
                dto.ShopName = item.branchFrenchName;
                dto.ShopId = item.Id;
                dto.StartActiveTime = item.StartActiveTime;
                dto.stateName = item.Neighborhood.Region.State.FrenchName;
                dto.SubCategoryName = item.ShopDal.SubCategoryDal.FrenchName;
                dto.SubCategoryId = item.ShopDal.SubCategoryDal.Id;
                if (_unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId).Count > 1)
                {
                    dto.Branches = new List<APIBranchesForShop>();
                    foreach (var i in _unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId))
                    {
                        if (i.Id != item.Id)
                        {

                            br.branchName = i.branchFrenchName;
                            br.BranchId = i.Id;
                            dto.Branches.Add(br);
                            br = new APIBranchesForShop();
                        }

                    }
                }
                var breaks = _unitOfWork.BreakRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIBreaksForBranchDto ABreak = new APIBreaksForBranchDto();
                foreach (var item1 in breaks)
                {
                    ABreak.start = DateTimeHelper.ConvertTimeToString(item1.start, TimeFormats.HH_MM_AM);
                    ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.breaks.Add(ABreak);
                    ABreak = new APIBreaksForBranchDto();

                }
                var PHOTOS = _unitOfWork.GalleryPhotoRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIGalleryphotoForBranchDto PHO = new APIGalleryphotoForBranchDto();
                foreach (var item2 in PHOTOS)
                {
                    PHO.photo = Convert.ToBase64String(item2.photo);
                    // ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.photos.Add(PHO);
                    PHO = new APIGalleryphotoForBranchDto();

                }

            }
            if (slug == "ru")
            {

                dto.email1 = item.email1;
                dto.email2 = item.email2;
                dto.hasBarnches = false;
                if (item.ShopDal.Branchs.Count > 1)
                {
                    dto.hasBarnches = true;
                }
                dto.instaLink = item.instaLink;
                dto.latitude = item.latitude;
                dto.longtitude = item.longtitude;
                dto.MainCategoryName = item.ShopDal.SubCategoryDal.MainCategoryDal.RussName;
                dto.MainCategoryId = item.ShopDal.SubCategoryDal.MainCategoryDalId;
                dto.EndActiveTime = item.EndActiveTime;
                dto.facebookLink = item.facebookLink;
                dto.NeighborhoodName = item.Neighborhood.RussName;
                dto.outDays = item.outDays;
                dto.phone1 = item.phone1;
                dto.phone2 = item.phone2;
                dto.phone3 = item.phone3;
                dto.RegionName = item.Neighborhood.Region.RussName;
                dto.ShopName = item.branchRussName;
                dto.ShopId = item.Id;
                dto.StartActiveTime = item.StartActiveTime;
                dto.stateName = item.Neighborhood.Region.State.RussName;
                dto.SubCategoryName = item.ShopDal.SubCategoryDal.RussName;
                dto.SubCategoryId = item.ShopDal.SubCategoryDal.Id;
                if (_unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId).Count > 1)
                {
                    dto.Branches = new List<APIBranchesForShop>();
                    foreach (var i in _unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId))
                    {
                        if (i.Id != item.Id)
                        {

                            br.branchName = i.branchRussName;
                            br.BranchId = i.Id;
                            dto.Branches.Add(br);
                            br = new APIBranchesForShop();
                        }

                    }
                }
                var breaks = _unitOfWork.BreakRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIBreaksForBranchDto ABreak = new APIBreaksForBranchDto();
                foreach (var item1 in breaks)
                {
                    ABreak.start = DateTimeHelper.ConvertTimeToString(item1.start, TimeFormats.HH_MM_AM);
                    ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.breaks.Add(ABreak);
                    ABreak = new APIBreaksForBranchDto();

                }
                var PHOTOS = _unitOfWork.GalleryPhotoRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIGalleryphotoForBranchDto PHO = new APIGalleryphotoForBranchDto();
                foreach (var item2 in PHOTOS)
                {
                    PHO.photo = Convert.ToBase64String(item2.photo);
                    // ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.photos.Add(PHO);
                    PHO = new APIGalleryphotoForBranchDto();

                }

            }
            if (slug == "pr")
            {

                dto.email1 = item.email1;
                dto.email2 = item.email2;
                dto.hasBarnches = false;
                if (item.ShopDal.Branchs.Count > 1)
                {
                    dto.hasBarnches = true;
                }
                dto.instaLink = item.instaLink;
                dto.latitude = item.latitude;
                dto.longtitude = item.longtitude;
                dto.MainCategoryName = item.ShopDal.SubCategoryDal.MainCategoryDal.PersianName;
                dto.MainCategoryId = item.ShopDal.SubCategoryDal.MainCategoryDalId;
                dto.EndActiveTime = item.EndActiveTime;
                dto.facebookLink = item.facebookLink;
                dto.NeighborhoodName = item.Neighborhood.PersianName;
                dto.outDays = item.outDays;
                dto.phone1 = item.phone1;
                dto.phone2 = item.phone2;
                dto.phone3 = item.phone3;
                dto.RegionName = item.Neighborhood.Region.PersianName;
                dto.ShopName = item.branchPersianName;
                dto.ShopId = item.Id;
                dto.StartActiveTime = item.StartActiveTime;
                dto.stateName = item.Neighborhood.Region.State.PersianName;
                dto.SubCategoryName = item.ShopDal.SubCategoryDal.PersianName;
                dto.SubCategoryId = item.ShopDal.SubCategoryDal.Id;
                if (_unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId).Count > 1)
                {
                    dto.Branches = new List<APIBranchesForShop>();
                    foreach (var i in _unitOfWork.BranchRepository.FindBy(x => x.ShopDalId == item.ShopDalId))
                    {
                        if (i.Id != item.Id)
                        {

                            br.branchName = i.branchPersianName;
                            br.BranchId = i.Id;
                            dto.Branches.Add(br);
                            br = new APIBranchesForShop();
                        }

                    }
                }
                var breaks = _unitOfWork.BreakRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIBreaksForBranchDto ABreak = new APIBreaksForBranchDto();
                foreach (var item1 in breaks)
                {
                    ABreak.start = DateTimeHelper.ConvertTimeToString(item1.start, TimeFormats.HH_MM_AM);
                    ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.breaks.Add(ABreak);
                    ABreak = new APIBreaksForBranchDto();

                }
                var PHOTOS = _unitOfWork.GalleryPhotoRepository.FindBy(x => x.BranchId == item.Id).ToList();
                APIGalleryphotoForBranchDto PHO = new APIGalleryphotoForBranchDto();
                foreach (var item2 in PHOTOS)
                {
                    PHO.photo = Convert.ToBase64String(item2.photo);
                    // ABreak.end = DateTimeHelper.ConvertTimeToString(item1.end, TimeFormats.HH_MM_AM);

                    dto.photos.Add(PHO);
                    PHO = new APIGalleryphotoForBranchDto();

                }

            }
            return dto;
       
            
        }

        public List<APIRegionDtoArabic> getAllRegions(int stateId,string slug)
        {
            var list = _unitOfWork.RegionRepository.GetAll().Where(x=>x.StateId==stateId).ToList();
            APIRegionDtoArabic dto = new APIRegionDtoArabic();
            List<APIRegionDtoArabic> res = new List<APIRegionDtoArabic>();
          
            foreach(var item in list)
            {
                if (slug == "ar")
                {
                    dto.Name = item.ArabicName;
                }
                if (slug == "en")
                {
                    dto.Name = item.EngName;
                }
                if (slug == "fr")
                {
                    dto.Name = item.FrenchName;
                }
                if (slug == "ru")
                {
                    dto.Name = item.RussName;
                }
                if (slug == "pr")
                {
                    dto.Name = item.PersianName;
                }
                dto.Id = item.Id;
                res.Add(dto);
                dto = new APIRegionDtoArabic();
            }

            return res;
        }
        public List<APIStateDtoArabic> getAllStates(string slug)
        {
            var list = _unitOfWork.StateRepository.GetAll();
            APIStateDtoArabic dto = new APIStateDtoArabic();
            List<APIStateDtoArabic> res = new List<APIStateDtoArabic>();
            foreach(var item in list )
            {
                if(slug == "ar")
                dto.ArabicName = item.ArabicName;
                if (slug == "en")
                    dto.ArabicName = item.EngName;
                if (slug == "fr")
                    dto.ArabicName = item.FrenchName;
                if (slug == "ru")
                    dto.ArabicName = item.RussName;
                if (slug == "pr")
                    dto.ArabicName = item.PersianName;
                dto.Id = item.Id;
                res.Add(dto);
                dto = new APIStateDtoArabic();
            }
            return res;
        }

        public List<APISubCategoryDtoAr> getAllSubCategoriesByMainCategory(int MainCatId,string slug)
        {
            var list = _unitOfWork.SubCategoryDalRepository.FindBy(x => x.MainCategoryDalId == MainCatId).ToList();
            APISubCategoryDtoAr obj = new APISubCategoryDtoAr();
            List<APISubCategoryDtoAr> result = new List<APISubCategoryDtoAr>();
            if (slug == "ar")
            {
                foreach (var item in list)
                {
                    obj.SubCatId = item.Id;
                    obj.MainCatId = item.MainCategoryDalId;
                    obj.MainCategoryName = item.MainCategoryDal.ArabicName;
                    obj.SubCatName = item.ArabicName;
                    if (item.icon != null)
                        obj.SubCategoryIcon = Convert.ToBase64String(item.icon);
                    result.Add(obj);
                    obj = new APISubCategoryDtoAr();
                }
            }
            if (slug == "en")
            {
                foreach (var item in list)
                {
                    obj.SubCatId = item.Id;
                    obj.MainCatId = item.MainCategoryDalId;
                    obj.MainCategoryName = item.MainCategoryDal.EngName;
                    obj.SubCatName = item.EngName;
                    if (item.icon != null)
                        obj.SubCategoryIcon = Convert.ToBase64String(item.iconEn);
                    result.Add(obj);
                    obj = new APISubCategoryDtoAr();
                }
            }
            if (slug == "fr")
            {
                foreach (var item in list)
                {
                    obj.SubCatId = item.Id;
                    obj.MainCatId = item.MainCategoryDalId;
                    obj.MainCategoryName = item.MainCategoryDal.FrenchName;
                    obj.SubCatName = item.FrenchName;
                    if (item.icon != null)
                        obj.SubCategoryIcon = Convert.ToBase64String(item.iconFr);
                    result.Add(obj);
                    obj = new APISubCategoryDtoAr();
                }
            }
            if (slug == "ru")
            {
                foreach (var item in list)
                {
                    obj.SubCatId = item.Id;
                    obj.MainCatId = item.MainCategoryDalId;
                    obj.MainCategoryName = item.MainCategoryDal.RussName;
                    obj.SubCatName = item.RussName;
                    if (item.icon != null)
                        obj.SubCategoryIcon = Convert.ToBase64String(item.iconRuss);
                    result.Add(obj);
                    obj = new APISubCategoryDtoAr();
                }
            }
            if (slug == "pr")
            {
                foreach (var item in list)
                {
                    obj.SubCatId = item.Id;
                    obj.MainCatId = item.MainCategoryDalId;
                    obj.MainCategoryName = item.MainCategoryDal.PersianName;
                    obj.SubCatName = item.PersianName;
                    if (item.icon != null)
                        obj.SubCategoryIcon = Convert.ToBase64String(item.iconPersian);
                    result.Add(obj);
                    obj = new APISubCategoryDtoAr();
                }
            }
            return result;
        }
        public List<SubCategoryDal> getConvinientSubCategories()
        {
            List<SubCategoryDal> res = new List<SubCategoryDal>();
            //  var list = _unitOfWork.SubCategoryDalRepository.GetAll();
            var t = _unitOfWork.SubCategoryDalRepository.GetAll().ToList();
            foreach (var r in t)
            {
                var p = _unitOfWork.ClientOfferRepository.GetAll().Where(x => x.Branch.ShopDal.SubCategoryDal.Id == r.Id);
                if (p.Count() > 0)
                {

                   
                            res.Add(r);
                    
                }
            }
            return res;
        }
        public List<APIOffersSubCategiesDtoAr> getAllOffersSubCategories( string slug)
        {
            var t = _unitOfWork.OfferRepository.GetAll();
            var list1 = _unitOfWork.SubCategetoryOffersRepository.GetAll().ToList().Where(x => x.Offers.Count > 0 && x.Offers.ToList().Where(y => y.Start.Date <= Utils.ServerNow.Date && y.end.Date >= Utils.ServerNow.Date).Any());
            var list2 = getConvinientSubCategories();
            APIOffersSubCategiesDtoAr dto = new APIOffersSubCategiesDtoAr();
            List<APIOffersSubCategiesDtoAr> res = new List<APIOffersSubCategiesDtoAr>();
            foreach (var item in list1)
            {
                if (slug == "ar")
                {
                    dto.ArabicName = item.ArabicName;
                }
                if (slug == "en")
                {
                    dto.ArabicName = item.EngName;
                }
                if (slug == "fr")
                {
                    dto.ArabicName = item.FrenchName;
                }
                if (slug == "ru")
                {
                    dto.ArabicName = item.RussName;
                }
                if (slug == "pr")
                {
                    dto.ArabicName = item.PersianName;
                }
                dto.id = item.Id;
                dto.isAdminOffer = true;
                dto.NumOfOffers = item.Offers.ToList().Where(x => x.Start.Date <= Utils.ServerNow.Date && Utils.ServerNow.Date <= x.end.Date).Count();
                res.Add(dto);
                dto = new APIOffersSubCategiesDtoAr();
            }
            foreach (var g in list2)
            {
                if (slug == "ar")
                {
                    dto.ArabicName = g.ArabicName;
                }
                if (slug == "en")
                {
                    dto.ArabicName = g.EngName;
                }
                if (slug == "fr")
                {
                    dto.ArabicName = g.FrenchName;
                }
                if (slug == "ru")
                {
                    dto.ArabicName = g.RussName;
                }
                if (slug == "pr")
                {
                    dto.ArabicName = g.PersianName;
                }
                dto.id = g.Id;
                dto.isAdminOffer = false;
                dto.NumOfOffers = _unitOfWork.ClientOfferRepository.GetAll().ToList().Where(x => x.Branch.ShopDal.SubCategoryDalId == g.Id && x.Start.Date <= Utils.ServerNow.Date && x.end.Date >= Utils.ServerNow.Date).Count();
                res.Add(dto);
                dto = new APIOffersSubCategiesDtoAr();
            }
            return res;
        }

        public APIOfferDtoAr getOfferById(int id, bool isAdminOffer, string slug)
        {
            
            APIOfferDtoAr result = new APIOfferDtoAr();
            if (isAdminOffer)  {
               var model = _unitOfWork.OfferRepository.FindById(id);
                result.BranchId = null;
                result.endDate = DateTimeHelper.ConvertDateToString(model.end, DateFormats.DD_MM_YYYY);
                result.StartDate = DateTimeHelper.ConvertDateToString(model.Start, DateFormats.DD_MM_YYYY);
                result.Dateofpuplishing = DateTimeHelper.ConvertDateToString(model.Dateofpuplishing, DateFormats.DD_MM_YYYY);
                result.Timeofpuplishing = DateTimeHelper.ConvertTimeToString(model.Timeofpuplishing, TimeFormats.HH_MM_AM);
                result.ShopName = "";
                if (model.photo != null)
                {
                    result.photo = Convert.ToBase64String(model.photo);
                }
                else { result.photo = ""; }
                if (slug == "ar")
                {
                    result.title = model.Atitle;
                    result.details = model.Adetails;
                }
                if (slug == "en")
                {
                    result.title = model.Etitle;
                    result.details = model.Edetails;
                }
                if (slug == "fr")
                {
                    result.title = model.Ftitle;
                    result.details = model.Fdetails;
                }
                if (slug == "ru")
                {
                    result.title = model.Rtitle;
                    result.details = model.Rdetails;
                }
                if (slug == "pr")
                {
                    result.title = model.Ptitle;
                    result.details = model.Pdetails;
                }
                result.Timeofpuplishing = DateTimeHelper.ConvertTimeToString(model.Timeofpuplishing, TimeFormats.HH_MM_AM);

                result.id = model.Id;
       
            }
            else
            {
                var model = _unitOfWork.ClientOfferRepository.FindById(id);
                result.BranchId = model.BranchId;
                result.endDate = DateTimeHelper.ConvertDateToString(model.end, DateFormats.DD_MM_YYYY);
                result.StartDate = DateTimeHelper.ConvertDateToString(model.Start, DateFormats.DD_MM_YYYY);
                result.Dateofpuplishing = DateTimeHelper.ConvertDateToString(model.Dateofpuplishing, DateFormats.DD_MM_YYYY);
           
                if (model.photo != null)
                {
                    result.photo = Convert.ToBase64String(model.photo);
                }
                else { result.photo = ""; }

                if (slug == "ar")
                {
                    result.title = model.title;
                    result.details = model.details;
                    result.ShopName = model.Branch.branchArabicName;
                }
                if (slug == "en")
                {
                    result.title = model.title;
                    result.details = model.details;
                    result.ShopName = model.Branch.branchEnglishName;
                }
                if (slug == "fr")
                {
                    result.title = model.title;
                    result.details = model.details;
                    result.ShopName = model.Branch.branchFrenchName;
                }
                if (slug == "ru")
                {
                    result.title = model.title;
                    result.details = model.details;
                    result.ShopName = model.Branch.branchRussName;
                }
                if (slug == "pr")
                {
                    result.title = model.title;
                    result.details = model.details;
                    result.ShopName = model.Branch.branchPersianName;
                }
                result.id = model.Id;
                result.Timeofpuplishing = DateTimeHelper.ConvertTimeToString(model.Timeofpuplishing, TimeFormats.HH_MM_AM);

            
            }
            return result;
        }
        public List<APIDisplayOffersOfSubCatDto> getoffersBySubCat(int subcat, bool isAdminOffer, string slug)
        {
            APIDisplayOffersOfSubCatDto dto = new APIDisplayOffersOfSubCatDto();
            List<APIDisplayOffersOfSubCatDto> res = new List<APIDisplayOffersOfSubCatDto>();
            if(isAdminOffer)
            {
                var list = _unitOfWork.OfferRepository.FindBy(x => x.SubCategetoryOffersId == subcat).ToList();
                foreach (var item in list)
                {
                    if(item.Start.Date <= Utils.ServerNow.Date && item.end.Date>=Utils.ServerNow.Date)
                    {
                        dto.id = item.Id;
                        if(slug == "ar")
                        {
                            dto.title = item.Atitle;
                        }
                        if (slug == "en")
                        {
                            dto.title = item.Etitle;
                        }
                        if (slug == "fr")
                        {
                            dto.title = item.Ftitle;
                        }
                        if (slug == "ru")
                        {
                            dto.title = item.Rtitle;
                        }
                        if (slug == "pr")
                        {
                            dto.title = item.Ptitle;
                        }
                        dto.dateOfPublish = DateTimeHelper.ConvertDateToString(item.Dateofpuplishing, DateFormats.DD_MM_YYYY);
                        res.Add(dto);
                        dto = new APIDisplayOffersOfSubCatDto();
                    }

                }
            }
            else
            {
                var list = _unitOfWork.ClientOfferRepository.FindBy(x => x.Branch.ShopDal.SubCategoryDalId == subcat).ToList();
                foreach (var item in list)
                {
                    if (item.Start.Date <= Utils.ServerNow.Date && item.end.Date >= Utils.ServerNow.Date)
                    {
                        dto.id = item.Id;
                        if (slug == "ar")
                        {
                            dto.title = item.title;
                        }
                        if (slug == "en")
                        {
                            dto.title = item.title;
                        }
                        if (slug == "fr")
                        {
                            dto.title = item.title;
                        }
                        if (slug == "ru")
                        {
                            dto.title = item.title;
                        }
                        if (slug == "pr")
                        {
                            dto.title = item.title;
                        }
                        dto.dateOfPublish = DateTimeHelper.ConvertDateToString(item.Dateofpuplishing, DateFormats.DD_MM_YYYY);
                        res.Add(dto);
                        dto = new APIDisplayOffersOfSubCatDto();
                    }

                }
            }
            return res;
        }
    }
}
