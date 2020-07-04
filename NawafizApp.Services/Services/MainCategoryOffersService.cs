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
   public class MainCategoryOffersService : IMainCategoryOffersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainCategoryOffersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addMainCategoryOffers(MainCategoryOffersDto dto)
        {
            MainCategoryOffers main = new MainCategoryOffers();
            main.Id = dto.Id;
            main.num = dto.num;
            main.ArabicName = dto.ArabicName;
            main.EngName = dto.EngName;
            main.FrenchName = dto.FrenchName;
            main.PersianName = dto.PersianName;
            main.RussName = dto.RussName;
            _unitOfWork.MainCategoryOffersRepository.Add(main);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteMainCategoryOffers(int id)
        {
            var m = _unitOfWork.MainCategoryOffersRepository.FindById(id);
            if (m == null)
            {
                return false;
            }
            _unitOfWork.MainCategoryOffersRepository.Remove(m);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(MainCategoryOffersDto dto)
        {
            var model = Mapper.Map<MainCategoryOffersDto, MainCategoryOffers>(dto);
            _unitOfWork.MainCategoryOffersRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }

        public MainCategoryOffersDto GetById(int id)
        {
            var model = _unitOfWork.MainCategoryOffersRepository.FindById(id);
            return Mapper.Map<MainCategoryOffers, MainCategoryOffersDto>(model);
        }

        public List<MainCategoryOffersDto> getMainCategoryOffers()
        {
            var list = _unitOfWork.MainCategoryOffersRepository.GetAll();
            return Mapper.Map<List<MainCategoryOffers>, List<MainCategoryOffersDto>>(list);
        }

        public bool IsCodeUnique(string num, int? editedId)
        {
            List<MainCategoryOffers> langs;
            if (editedId.HasValue)
                langs = _unitOfWork.MainCategoryOffersRepository.FindBy(m => m.Id != editedId);
            else
                langs = _unitOfWork.MainCategoryOffersRepository.GetAll();

            return !langs.Where(m => m.num.ToString() == num).Any();
        }
    }
}
