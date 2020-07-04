using NawafizApp.Domain;
using NawafizApp.Domain.Entities;
using NawafizApp.Services.Interfaces;
using NawafizApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;
using AutoMapper;

namespace NawafizApp.Services.Services
{
   public class SubCategoryDalService :ISubCategoryDalService
    {

        private readonly IUnitOfWork _unitOfWork;
        public SubCategoryDalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addSubCategoryDal(SubCategoryDalDto dto)
        {
            SubCategoryDal sub = new SubCategoryDal();
            sub.Id = dto.Id;
            sub.ArabicName = dto.ArabicName;
            sub.EngName = dto.EngName;
            sub.FrenchName = dto.FrenchName;
            sub.PersianName = dto.PersianName;
            sub.RussName = dto.RussName;
            sub.icon = dto.icon;
            sub.iconEn = dto.iconEn;
            sub.iconFr = dto.iconFr;
            sub.iconPersian = dto.iconPersian;
            sub.iconRuss = dto.iconRuss;
            sub.MainCategoryDalId = dto.MainCategoryDalId;
            _unitOfWork.SubCategoryDalRepository.Add(sub);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteSubCategoryDal(int id)
        {
            var sub = _unitOfWork.SubCategoryDalRepository.FindById(id);
            if (sub == null) return false;
            _unitOfWork.SubCategoryDalRepository.Remove(sub);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(SubCategoryDalDto dto)
        {
            var model = _unitOfWork.SubCategoryDalRepository.FindById(dto.Id);
            model.MainCategoryDalId = dto.MainCategoryDalId;
            model.ArabicName = dto.ArabicName;
            model.EngName = dto.EngName;
            model.FrenchName = dto.FrenchName;
            model.PersianName = dto.PersianName;
            model.RussName = dto.RussName;
            if (dto.icon!=null)
            {
                model.icon = dto.icon;
            }
            if (dto.iconEn!=null)
            {
                model.iconEn = dto.iconEn;

            }
            if (dto.iconFr != null)
            {
                model.iconFr = dto.iconFr;

            }
            if (dto.iconPersian != null)
            {
                model.iconPersian = dto.iconPersian;

            }
            if (dto.iconRuss != null)
            {
                model.iconRuss = dto.iconRuss;

            }
            _unitOfWork.SubCategoryDalRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<SubCategoryDalDto> getAllSubCategoriesDal()
        {
            var list = Mapper.Map<List<SubCategoryDal>, List<SubCategoryDalDto>>(_unitOfWork.SubCategoryDalRepository.GetAll());
            foreach (var item in list)
            {
                item.MainCategoryDalName = _unitOfWork.MainCategoryDalRepository.FindById(item.MainCategoryDalId).ArabicName;
            }
            return list;
        }

        public List<SubCategoryDalDto> getAllSubCategoriesByMainCatrgory(int MainCatId)
        {
            var list = Mapper.Map<List<SubCategoryDal>, List<SubCategoryDalDto>>(_unitOfWork.SubCategoryDalRepository.FindBy(x => x.MainCategoryDalId == MainCatId));
            foreach (var item in list)
            {
                item.MainCategoryDalName = _unitOfWork.MainCategoryDalRepository.FindById(item.MainCategoryDalId).ArabicName;
            }
            return list;
        }

        public SubCategoryDalDto GetById(int id)
        {
            var model = _unitOfWork.SubCategoryDalRepository.FindById(id);
            return Mapper.Map<SubCategoryDal, SubCategoryDalDto>(model);
        }

        public SubCategoryDalDto getSubCategoryDalForFullSize(int id)
        {
            SubCategoryDalDto dto = new SubCategoryDalDto();
            SubCategoryDal sub = _unitOfWork.SubCategoryDalRepository.FindById(id);
            dto.Id = dto.Id;
            dto.ArabicName = sub.ArabicName;
            dto.EngName = sub.EngName;
            dto.FrenchName = sub.FrenchName;
            dto.PersianName = sub.PersianName;
            dto.RussName = sub.RussName;
            dto.num = sub.num;
            dto.icon = sub.icon;
            dto.iconEn = sub.iconEn;
            dto.iconFr = sub.iconFr;
            dto.iconPersian = sub.iconPersian;
            dto.iconRuss = sub.iconRuss;
            return dto;
        }
    }
}
