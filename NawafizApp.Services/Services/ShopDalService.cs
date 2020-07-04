using NawafizApp.Domain;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;
using NawafizApp.Domain.Entities;
using AutoMapper;

namespace NawafizApp.Services.Services
{
   public class ShopDalService: IShopDalService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopDalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int addShopDal(ShopDalDto dto)
        {
            var model = Mapper.Map<ShopDalDto, ShopDal>(dto);
            _unitOfWork.ShopDalRepository.Add(model);
            _unitOfWork.SaveChanges();
            return model.Id;
        }

        public bool deleteShopDalD(int ShopDalDId)
        {
            ShopDal user = _unitOfWork.ShopDalRepository.FindById(ShopDalDId);
            if (user == null)
                return false;
            _unitOfWork.ShopDalRepository.Remove(user);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(ShopDalDto dto)
        {
            ShopDal shop = _unitOfWork.ShopDalRepository.FindById(dto.Id);
            shop.Id = dto.Id;
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
            shop.UserId = dto.UserId;          
            if ( dto.BranchIds != null)
            {
                shop.Branchs = new List<Branch>();
                foreach (int i in dto.BranchIds)
                {
                    shop.Branchs.Add(_unitOfWork.BranchRepository.FindById(i));
                }
            }
            if (shop == null)
                return false;
            _unitOfWork.ShopDalRepository.Update(shop);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<ShopDalDto> getAllShopDal()
        {
           
            var list = Mapper.Map<List<ShopDal>, List<ShopDalDto>>(_unitOfWork.ShopDalRepository.GetAll().ToList());
           
            foreach (var item in list)
            {
                if (!String.IsNullOrEmpty(item.branchesname))
                {
                    item.branchesname = _unitOfWork.BranchRepository.FindById(item.SubCategoryDalId).branchArabicName + "-";
                }
             
                
                
            }
            return list;
        }

        public List<ShopDalDto> getAllShopDalbysubCategory(int subCategoryId)
        {
            var list = Mapper.Map<List<ShopDal>, List<ShopDalDto>>(_unitOfWork.ShopDalRepository.FindBy(x => x.SubCategoryDalId == subCategoryId));
            foreach (var item in list)
            {

                item.branchesname = _unitOfWork.BranchRepository.FindById(item.SubCategoryDalId).branchArabicName + "-";


            }
            return list;
        }

        public List<ShopDalSearchResDto> getAllShopDalfilter(FilterDto filter)
        {
            var list = _unitOfWork.ShopDalRepository.GetAll();
            List<ShopDalSearchResDto> listres = new List<ShopDalSearchResDto>();
            if (filter.maincat!=0)
            {
                list = list.Where(x => x.SubCategoryDal.MainCategoryDalId == filter.maincat).ToList();
            }
            if (filter.subcatId!=0)
            {
                list = list.Where(x => x.SubCategoryDalId == filter.subcatId).ToList();
            }
            if (filter.shopDalId!=0)
            {
                list = list.Where(x => x.Id == filter.shopDalId).ToList();
            }
            if (!String.IsNullOrEmpty(filter.shopDalName))
            {
                list = list.Where(x => x.ArabicName.Contains(filter.shopDalName)).ToList();
            }
            ShopDalSearchResDto res = new ShopDalSearchResDto();
            foreach (var item in list)
            {
                res.ArabicName = item.ArabicName;
                res.ArabicinvesterName = item.ArabicinvesterName;
                res.maincatName = item.SubCategoryDal.MainCategoryDal.ArabicName;
                res.subcatName = item.SubCategoryDal.ArabicName;
                res.Id = item.Id;
                listres.Add(res);
                res = new ShopDalSearchResDto();
            }
            return listres;
        }

        public ShopDalDto GetById(int id)
        {
            var model = _unitOfWork.ShopDalRepository.FindById(id);
            return Mapper.Map<ShopDal, ShopDalDto>(model);
        }
    }
}
