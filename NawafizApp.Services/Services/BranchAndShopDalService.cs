using NawafizApp.Domain;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;
using NawafizApp.Domain.Entities;
using NawafizApp.Services.Identity;
using AutoMapper;
using NawafizApp.Common;

namespace NawafizApp.Services.Services
{
   public class BranchAndShopDalService : IBranchAndShopDalService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BranchAndShopDalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int AddBranchAndShopDal(BranchAndShopDalDto dto)
        {
            Branch b = new Branch();
            ShopDal shop = new ShopDal();
           
            shop.ArabicName = dto.ArabicName;
            shop.EngName = dto.EngName;
            shop.FrenchName = dto.FrenchName;
            shop.PersianName = dto.PersianName;
            shop.RussName = dto.RussName;
            shop.ArabicinvesterName = dto.ArabicinvesterName;
            shop.EnginvesterName = dto.EnginvesterName;
            shop.FrenchinvesterName = dto.FrenchinvesterName;
            shop.PersianinvesterName = dto.PersianinvesterName;
            shop.RussinvesterName = dto.RussinvesterName;
            shop.SubCategoryDalId = dto.SubCategoryDalId;
            if (dto.UserId!=null)
            {
                shop.UserId = dto.UserId;
            }            
            _unitOfWork.ShopDalRepository.Add(shop);
            _unitOfWork.SaveChanges();

            b.branchArabicName = dto.branchArabicName;
            b.branchEnglishName = dto.branchEnglishName;
            b.branchFrenchName = dto.branchFrenchName;
            b.branchPersianName = dto.branchPersianName;
            b.branchRussName = dto.branchRussName;
            b.facebookLink = dto.facebookLink;
            b.instaLink = dto.instaLink;
            b.email1 = dto.email1;
            b.email2 = dto.email2;
            b.phone1 = dto.phone1;
            b.phone2 = dto.phone2;
            b.phone3 = dto.phone3;
            b.longtitude = dto.longtitude;
            b.latitude = dto.latitude;
            b.outDays = dto.outDays;
            b.StartActiveTime = dto.StartActiveTime;
            b.EndActiveTime = dto.EndActiveTime;          
            b.ShopDalId = shop.Id;
            b.NeighborhoodId = dto.NeighborhoodId;
            _unitOfWork.BranchRepository.Add(b);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteBranchAndShopDalDto(int ShopDalId, int BId)
        {
            var s = _unitOfWork.ShopDalRepository.FindById(ShopDalId);
            //var b = _unitOfWork.BranchRepository.FindById(BId);
            if (s == null)
            {
                return false;
            }
            //if (b == null)
            //{
            //    return false;
            //}
            _unitOfWork.ShopDalRepository.Remove(s);
            //_unitOfWork.BranchRepository.Remove(b);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(BranchAndShopDalDto dto)
        {
            Branch b = _unitOfWork.BranchRepository.FindById(dto.Id);
            ShopDal shop = _unitOfWork.ShopDalRepository.FindById(dto.shopId);
            shop.ArabicName = dto.ArabicName;
            shop.EngName = dto.EngName;
            shop.FrenchName = dto.FrenchName;
            shop.PersianName = dto.PersianName;
            shop.RussName = dto.RussName;
            shop.ArabicinvesterName = dto.ArabicinvesterName;
            shop.EnginvesterName = dto.EnginvesterName;
            shop.FrenchinvesterName = dto.FrenchinvesterName;
            shop.PersianinvesterName = dto.PersianinvesterName;
            shop.RussinvesterName = dto.RussinvesterName;
            shop.SubCategoryDalId = dto.SubCategoryDalId;
            if (dto.UserId != null)
            {
                shop.UserId = dto.UserId;
            }
            _unitOfWork.ShopDalRepository.Update(shop);
            _unitOfWork.SaveChanges();

            b.branchArabicName = dto.branchArabicName;
            b.branchEnglishName = dto.branchEnglishName;
            b.branchFrenchName = dto.branchFrenchName;
            b.branchPersianName = dto.branchPersianName;
            b.branchRussName = dto.branchRussName;
            b.facebookLink = dto.facebookLink;
            b.instaLink = dto.instaLink;
            b.email1 = dto.email1;
            b.email2 = dto.email2;
            b.phone1 = dto.phone1;
            b.phone2 = dto.phone2;
            b.phone3 = dto.phone3;
            b.longtitude = dto.longtitude;
            b.latitude = dto.latitude;
            if (!String.IsNullOrEmpty(dto.outDays))
            {
                b.outDays = dto.outDays;
            }
            if (dto.StartActiveTime!=null)
            {
                b.StartActiveTime = dto.StartActiveTime;
            }
            if (dto.EndActiveTime!=null)
            {
                b.EndActiveTime = dto.EndActiveTime;
            }
           
            b.ShopDalId = shop.Id;
            if (dto.NeighborhoodId!=0)
            {
                b.NeighborhoodId = dto.NeighborhoodId;
            }
           
            _unitOfWork.BranchRepository.Update(b);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<BranchAndShopDalDto> getAllBranchAndShopDal()
        {
            var list = _unitOfWork.ShopDalRepository.GetAll().ToList();
            BranchAndShopDalDto sAndB = new BranchAndShopDalDto();
            List<BranchAndShopDalDto> list3 = new List<BranchAndShopDalDto>();
            foreach (var item in list)
            {
                var list1 = _unitOfWork.BranchRepository.FindBy(x=>x.ShopDalId==item.Id);
                sAndB.shopId = item.Id;
                sAndB.ArabicName = item.ArabicName;
                sAndB.EngName = item.EngName;
                sAndB.FrenchName = item.FrenchName;
                sAndB.PersianName = item.PersianName;
                sAndB.RussName = item.RussName;
                sAndB.ArabicinvesterName = item.ArabicinvesterName;
                sAndB.FrenchinvesterName = item.FrenchinvesterName;
                sAndB.EnginvesterName = item.EnginvesterName;
                sAndB.PersianinvesterName = item.PersianinvesterName;
                sAndB.RussinvesterName = item.RussinvesterName;
                sAndB.SubCategoryDalId = item.SubCategoryDalId;
                sAndB.SubCategoryDalName = item.SubCategoryDal.ArabicName;
                sAndB.mainCategoryId = item.SubCategoryDal.MainCategoryDal.Id;
                sAndB.mainCategoryName = item.SubCategoryDal.MainCategoryDal.ArabicName;
                if (item.UserId != null)
                {                    
                    sAndB.userName = item.User.FullName;
                }
                foreach (var item2 in item.Branchs)
                {
                    sAndB.Id = item2.Id;                  
                    sAndB.branchArabicName = item2.branchArabicName;
                    sAndB.branchEnglishName = item2.branchEnglishName;
                    sAndB.branchFrenchName = item2.branchFrenchName;
                    sAndB.branchPersianName = item2.branchPersianName;
                    sAndB.branchRussName = item2.branchRussName;
                    sAndB.facebookLink = item2.facebookLink;
                    sAndB.instaLink = item2.instaLink;
                    sAndB.email1 =item2.email1;
                    sAndB.email2 = item2.email2;
                    sAndB.phone1 = item2.phone1;
                    sAndB.phone2 = item2.phone2;
                    sAndB.phone3 = item2.phone3;
                    sAndB.longtitude = item2.longtitude;
                    sAndB.latitude = item2.latitude;
                    sAndB.StartActiveTime = item2.StartActiveTime;
                    sAndB.EndActiveTime = item2.EndActiveTime;
                    sAndB.outDays = item2.outDays;
                    sAndB.NeighborhoodId = item2.NeighborhoodId;
                    sAndB.NeighborhoodName = item2.Neighborhood.ArabicName;
                    sAndB.regionId = item2.Neighborhood.Region.Id;
                    sAndB.regionName = item2.Neighborhood.Region.ArabicName;
                    sAndB.stateId = item2.Neighborhood.Region.State.Id;
                    sAndB.stateName = item2.Neighborhood.Region.State.ArabicName;
                }              
                list3.Add(sAndB);
                sAndB = new BranchAndShopDalDto();
            }         
            return list3;
        }

        public BranchAndShopDalDto GetById(int id,int bid)
        {
            var list = _unitOfWork.ShopDalRepository.FindById(id);
            var list2 = _unitOfWork.BranchRepository.FindById(bid);
            BranchAndShopDalDto sAndB = new BranchAndShopDalDto();
    
            sAndB.shopId = list.Id;
            sAndB.ArabicName = list.ArabicName;
            sAndB.EngName = list.EngName;
            sAndB.FrenchName = list.FrenchName;
            sAndB.PersianName = list.PersianName;
            sAndB.RussName = list.RussName;
            sAndB.ArabicinvesterName = list.ArabicinvesterName;
            sAndB.FrenchinvesterName = list.FrenchinvesterName;
            sAndB.EnginvesterName = list.EnginvesterName;
            sAndB.PersianinvesterName = list.PersianinvesterName;
            sAndB.RussinvesterName = list.RussinvesterName;
            sAndB.SubCategoryDalId = list.SubCategoryDalId;
            sAndB.SubCategoryDalName = list.SubCategoryDal.ArabicName;
            sAndB.mainCategoryId = list.SubCategoryDal.MainCategoryDal.Id;
            sAndB.mainCategoryName = list.SubCategoryDal.MainCategoryDal.ArabicName;
            if (list.UserId != null)
            {
                sAndB.UserId = list.UserId;
                sAndB.userName = list.User.FullName;
            }
            if (list2!=null)
            {
                sAndB.Id = list2.Id;
                sAndB.branchArabicName = list2.branchArabicName;
                sAndB.branchEnglishName = list2.branchEnglishName;
                sAndB.branchFrenchName = list2.branchFrenchName;
                sAndB.branchPersianName = list2.branchPersianName;
                sAndB.branchRussName = list2.branchRussName;
                sAndB.facebookLink = list2.facebookLink;
                sAndB.instaLink = list2.instaLink;
                sAndB.email1 = list2.email1;
                sAndB.email2 = list2.email2;
                sAndB.phone1 = list2.phone1;
                sAndB.phone2 = list2.phone2;
                sAndB.phone3 = list2.phone3;
                sAndB.longtitude = list2.longtitude;
                sAndB.latitude = list2.latitude;
                sAndB.StartActiveTime = list2.StartActiveTime;
                sAndB.EndActiveTime = list2.EndActiveTime;
                sAndB.startstr = DateTimeHelper.ConvertTimeToString(sAndB.StartActiveTime, TimeFormats.HH_MM_AM);
                sAndB.endstr = DateTimeHelper.ConvertTimeToString(sAndB.EndActiveTime, TimeFormats.HH_MM_AM);
                sAndB.outDays = list2.outDays;
                sAndB.NeighborhoodId = list2.NeighborhoodId;
                sAndB.NeighborhoodName = list2.Neighborhood.ArabicName;
                sAndB.regionId = list2.Neighborhood.Region.Id;
                sAndB.regionName = list2.Neighborhood.Region.ArabicName;
                sAndB.stateId = list2.Neighborhood.Region.State.Id;
                sAndB.stateName = list2.Neighborhood.Region.State.ArabicName;
            }
          
            //foreach (var item2 in list.Branchs)
            //{
            //    sAndB.Id = item2.Id;
            //    sAndB.branchArabicName = item2.branchArabicName;
            //    sAndB.branchEnglishName = item2.branchEnglishName;
            //    sAndB.branchFrenchName = item2.branchFrenchName;
            //    sAndB.branchPersianName = item2.branchPersianName;
            //    sAndB.branchRussName = item2.branchRussName;
            //    sAndB.facebookLink = item2.facebookLink;
            //    sAndB.instaLink = item2.instaLink;
            //    sAndB.email1 = item2.email1;
            //    sAndB.email2 = item2.email2;
            //    sAndB.phone1 = item2.phone1;
            //    sAndB.phone2 = item2.phone2;
            //    sAndB.phone3 = item2.phone3;
            //    sAndB.longtitude = item2.longtitude;
            //    sAndB.latitude = item2.latitude;
            //    sAndB.StartActiveTime = item2.StartActiveTime;
            //    sAndB.EndActiveTime = item2.EndActiveTime;
            //    sAndB.outDays = item2.outDays;
            //    sAndB.NeighborhoodId = item2.NeighborhoodId;
            //    sAndB.NeighborhoodName = item2.Neighborhood.ArabicName;
            //    sAndB.regionId = item2.Neighborhood.Region.Id;
            //    sAndB.regionName = item2.Neighborhood.Region.ArabicName;
            //    sAndB.stateId = item2.Neighborhood.Region.State.Id;
            //    sAndB.stateName = item2.Neighborhood.Region.State.ArabicName;

            //}


            return sAndB;
        }

        public BranchAndShopDalDto getofferForFullSize(int id,int ShId)
        {
            BranchAndShopDalDto dto = new BranchAndShopDalDto();
            Branch b = _unitOfWork.BranchRepository.FindById(id);
            ShopDal sh = _unitOfWork.ShopDalRepository.FindById(ShId);
            dto.branchArabicName = b.branchArabicName;
            dto.branchEnglishName = b.branchEnglishName;
            dto.branchFrenchName = b.branchFrenchName;
            dto.branchPersianName = b.branchPersianName;
            dto.branchRussName = b.branchRussName;
            dto.email1 = b.email1;
            dto.email2 = b.email2;
            dto.phone1 = b.phone1;
            dto.phone2 = b.phone2;
            dto.phone3 = b.phone3;
            dto.longtitude = b.longtitude;
            dto.latitude = b.latitude;
            dto.StartActiveTime = b.StartActiveTime;
            dto.EndActiveTime = b.EndActiveTime;
            dto.outDays = b.outDays;
            dto.shopId = b.ShopDalId;
            dto.ArabicName = _unitOfWork.ShopDalRepository.FindById(b.ShopDalId).ArabicName;
            dto.userName = _unitOfWork.UserRepository.FindById(sh.UserId).UserName;
            dto.NeighborhoodId = b.NeighborhoodId;
            return dto;

        }
    }
}
