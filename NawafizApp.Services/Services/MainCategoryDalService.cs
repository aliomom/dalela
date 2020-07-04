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
   public class MainCategoryDalService: IMainCategoryDalService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainCategoryDalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addMainCategoryDal(MainCategoryDalDto dto)
        {
            MainCategoryDal m = new MainCategoryDal();
            m.Id = dto.Id;
            m.ArabicName = dto.ArabicName;
            m.EngName = dto.EngName;
            m.FrenchName = dto.FrenchName;
            m.PersianName = dto.PersianName;
            m.RussName = dto.RussName;
            m.icon = dto.icon;
            m.iconEn = dto.iconEn;
            m.iconFr = dto.iconFr;
            m.iconPersian = dto.iconPersian;
            m.iconRuss = dto.iconRuss;
            m.num = dto.num;
            _unitOfWork.MainCategoryDalRepository.Add(m);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteMainCategoryDal(int id)
        {
            var m = _unitOfWork.MainCategoryDalRepository.FindById(id);
            if (m==null)
            {
                return false;
            }
            _unitOfWork.MainCategoryDalRepository.Remove(m);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(MainCategoryDalDto dto)
        {
            var model = _unitOfWork.MainCategoryDalRepository.FindById(dto.Id);
            model.ArabicName = dto.ArabicName;
            model.EngName = dto.EngName;
            model.FrenchName = dto.FrenchName;
            model.PersianName = dto.PersianName;
            model.RussName = dto.RussName;
            model.num = dto.num;
            if (dto.icon!=null)
            {
                model.icon = dto.icon;
            }
            if (dto.iconEn!=null)
            {
                model.iconEn = dto.iconEn;
            }
            if (dto.iconFr!=null)
            {
                model.iconFr = dto.iconFr;
            }
            if (dto.iconPersian!=null)
            {
                model.iconPersian = dto.iconPersian;
            }
            if (dto.iconRuss!=null)
            {
                model.iconRuss = dto.iconRuss;
            }
           
           
            _unitOfWork.MainCategoryDalRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }

        public MainCategoryDalDto GetById(int id)
        {
            var model = _unitOfWork.MainCategoryDalRepository.FindById(id);
            return Mapper.Map<MainCategoryDal, MainCategoryDalDto>(model);
        }

        public List<MainCategoryDalDto> getMainCategoryDal()
        {
            var list = _unitOfWork.MainCategoryDalRepository.GetAll();
            return Mapper.Map<List<MainCategoryDal>, List<MainCategoryDalDto>>(list);
        }

        public MainCategoryDalDto getMainCategoryDalForFullSize(int id)
        {
            MainCategoryDalDto dto = new MainCategoryDalDto();
            MainCategoryDal main = _unitOfWork.MainCategoryDalRepository.FindById(id);
            dto.Id = dto.Id;   
            dto.ArabicName = main.ArabicName;
            dto.EngName = main.EngName;
            dto.FrenchName = main.FrenchName;
            dto.PersianName = main.PersianName;
            dto.RussName = main.RussName;
            dto.num = main.num;        
            dto.icon = main.icon;
            dto.iconEn = main.iconEn;
            dto.iconFr = main.iconFr;
            dto.iconPersian = main.iconPersian;
            dto.iconRuss = main.iconRuss;
            return dto;
        }

        public bool IsCodeUnique(string num, int? editedId)
        {
            List<MainCategoryDal> langs;
            if (editedId.HasValue)
                langs = _unitOfWork.MainCategoryDalRepository.FindBy(m => m.Id != editedId);
            else
                langs = _unitOfWork.MainCategoryDalRepository.GetAll();

            return !langs.Where(m => m.num.ToString() == num).Any();
        }
    }
}
