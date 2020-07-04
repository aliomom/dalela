using NawafizApp.Domain;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;
using NawafizApp.Domain.Entities;
using NawafizApp.Common;
using AutoMapper;

namespace NawafizApp.Services.Services
{
 public   class BranchService:IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BranchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addBranch(BranchDto dto)
        {
            Branch b = new Branch();
            b.Id = dto.Id;
            b.branchArabicName = dto.branchArabicName;
            b.branchEnglishName = dto.branchEnglishName;
            b.branchFrenchName = dto.branchFrenchName;
            b.branchPersianName= dto.branchPersianName;
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
            b.NeighborhoodId = dto.NeighborhoodId;
            b.ShopDalId = dto.ShopDalId.GetValueOrDefault();            
            _unitOfWork.BranchRepository.Add(b);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteBranch(int BranchId)
        {
            var b = _unitOfWork.BranchRepository.FindById(BranchId);
            if (b == null)
            {
                return false;
            }

            _unitOfWork.BranchRepository.Remove(b);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(BranchDto dto)
        {
            Branch b = _unitOfWork.BranchRepository.FindById(dto.Id);
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
            if (dto.StartActiveTime != null)
            {
                b.StartActiveTime = dto.StartActiveTime;
            }
            if (dto.EndActiveTime != null)
            {
                b.EndActiveTime = dto.EndActiveTime;
            }

            b.ShopDalId = dto.ShopDalId.GetValueOrDefault();
            if (dto.NeighborhoodId!=0)
            {
                b.NeighborhoodId = dto.NeighborhoodId;
            }
         
            _unitOfWork.BranchRepository.Update(b);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<BranchDto> getAllBranch()
        {
            var list = Mapper.Map<List<Branch>, List<BranchDto>>(_unitOfWork.BranchRepository.GetAll().ToList());
            foreach (var item in list)
            {
                item.NeighborhoodName = _unitOfWork.NeighborhoodRepository.FindById(item.NeighborhoodId).ArabicName;            
                item.ShopDalName = _unitOfWork.ShopDalRepository.FindById(item.ShopDalId).ArabicName;
                item.stateId = _unitOfWork.NeighborhoodRepository.FindById(item.NeighborhoodId).Region.State.Id;
                item.stateName = _unitOfWork.NeighborhoodRepository.FindById(item.NeighborhoodId).Region.State.ArabicName;
                item.RegionId = _unitOfWork.NeighborhoodRepository.FindById(item.NeighborhoodId).Region.Id;
                item.RegionName = _unitOfWork.NeighborhoodRepository.FindById(item.NeighborhoodId).Region.ArabicName;
            }
            return list;
        }
        public List<BranchDto> getAllBranchbyShopdalid( int? id)
        {
            var list = Mapper.Map<List<Branch>, List<BranchDto>>(_unitOfWork.BranchRepository.GetAll().Where(x=>x.ShopDalId==id).ToList());
            foreach (var item in list)
            {
                item.NeighborhoodName = _unitOfWork.NeighborhoodRepository.FindById(item.NeighborhoodId).ArabicName;
                item.ShopDalName = _unitOfWork.ShopDalRepository.FindById(item.ShopDalId).ArabicName;
                item.stateId = _unitOfWork.BranchRepository.FindById(item.Id).Neighborhood.Region.State.Id;
                item.stateName = _unitOfWork.BranchRepository.FindById(item.Id).Neighborhood.Region.State.ArabicName;
                item.RegionId = _unitOfWork.BranchRepository.FindById(item.Id).Neighborhood.Region.Id;

                item.RegionName = _unitOfWork.BranchRepository.FindById(item.Id).Neighborhood.Region.ArabicName;
                item.sstr = DateTimeHelper.ConvertTimeToString(item.StartActiveTime, TimeFormats.HH_MM_AM);
                item.estr = DateTimeHelper.ConvertTimeToString(item.EndActiveTime, TimeFormats.HH_MM_AM);
                item.phone1 = _unitOfWork.BranchRepository.FindById(item.Id).phone1;
                item.phone2 = _unitOfWork.BranchRepository.FindById(item.Id).phone2;
                item.phone3 = _unitOfWork.BranchRepository.FindById(item.Id).phone3;
                item.email1 = _unitOfWork.BranchRepository.FindById(item.Id).email1;
                item.email2 = _unitOfWork.BranchRepository.FindById(item.Id).email2;
                item.outDays = _unitOfWork.BranchRepository.FindById(item.Id).outDays;
                item.StartActiveTime = _unitOfWork.BranchRepository.FindById(item.Id).StartActiveTime;
                item.EndActiveTime = _unitOfWork.BranchRepository.FindById(item.Id).EndActiveTime;
                item.facebookLink = _unitOfWork.BranchRepository.FindById(item.Id).facebookLink;
                item.instaLink = _unitOfWork.BranchRepository.FindById(item.Id).instaLink;
            }
            return list;
        }
        public List<BranchDto> getAllBranchsByNeihborhoods(int NeihborhoodId)
        {
            var m = _unitOfWork.BranchRepository.GetAll().Where(x => x.NeighborhoodId == NeihborhoodId).ToList();
            return Mapper.Map<List<Branch>, List<BranchDto>>(m);
        }

        public BranchDto GetById(int id)
        {
            var list2 = _unitOfWork.BranchRepository.FindById(id);
          
            BranchDto sAndB = new BranchDto();
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
            sAndB.sstr = DateTimeHelper.ConvertTimeToString(sAndB.StartActiveTime, TimeFormats.HH_MM_AM);
            sAndB.estr = DateTimeHelper.ConvertTimeToString(sAndB.EndActiveTime, TimeFormats.HH_MM_AM);
            sAndB.outDays = list2.outDays;
            sAndB.NeighborhoodId = list2.NeighborhoodId;
            sAndB.NeighborhoodName = list2.Neighborhood.ArabicName;
            sAndB.RegionId = list2.Neighborhood.Region.Id;
            sAndB.RegionName = list2.Neighborhood.Region.ArabicName;
            sAndB.stateId = list2.Neighborhood.Region.State.Id;
            sAndB.stateName = list2.Neighborhood.Region.State.ArabicName;
            return sAndB;
        }
    }
}
