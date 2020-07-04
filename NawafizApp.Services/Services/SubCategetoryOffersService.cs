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
   public class SubCategetoryOffersService : ISubCategetoryOffersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubCategetoryOffersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addSubCategetoryOffers(SubCategetoryOffersDto dto)
        {
            SubCategetoryOffers sub = new SubCategetoryOffers();
            sub.Id = dto.Id;
            sub.num = dto.num;
            sub.ArabicName = dto.ArabicName;
            sub.EngName = dto.EngName;
            sub.FrenchName = dto.FrenchName;
            sub.PersianName = dto.PersianName;
            sub.RussName = dto.RussName;
            sub.MainCategoryOffersId = dto.MainCategoryOffersId;         
            _unitOfWork.SubCategetoryOffersRepository.Add(sub);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteSubCategetoryOffers(int id)
        {
            var sub = _unitOfWork.SubCategetoryOffersRepository.FindById(id);
            if (sub == null) return false;
            _unitOfWork.SubCategetoryOffersRepository.Remove(sub);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(SubCategetoryOffersDto dto)
        {
            var model = Mapper.Map<SubCategetoryOffersDto, SubCategetoryOffers>(dto);
            _unitOfWork.SubCategetoryOffersRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<SubCategetoryOffersDto> getAllSubCategetoryOffers()
        {
            var list = Mapper.Map<List<SubCategetoryOffers>, List<SubCategetoryOffersDto>>(_unitOfWork.SubCategetoryOffersRepository.GetAll());
            foreach (var item in list)
            {
                item.MainCategoryOffersName = _unitOfWork.MainCategoryOffersRepository.FindById(item.MainCategoryOffersId).ArabicName;
            }
            return list;
        }

        public List<SubCategetoryOffersDto> getAllSubCategoriesByMainCatrgory(int MainCatId)
        {
            var list = Mapper.Map<List<SubCategetoryOffers>, List<SubCategetoryOffersDto>>(_unitOfWork.SubCategetoryOffersRepository.FindBy(x => x.MainCategoryOffersId == MainCatId));
            foreach (var item in list)
            {
                item.MainCategoryOffersName = _unitOfWork.MainCategoryOffersRepository.FindById(item.MainCategoryOffersId).ArabicName;
            }
            return list;
        }

        public SubCategetoryOffersDto GetById(int id)
        {
            var model = _unitOfWork.SubCategetoryOffersRepository.FindById(id);
            return Mapper.Map<SubCategetoryOffers, SubCategetoryOffersDto>(model);
        }
        public bool IsCodeUnique(string num, int? editedId)
        {
            List<SubCategetoryOffers> langs;
            if (editedId.HasValue)
                langs = _unitOfWork.SubCategetoryOffersRepository.FindBy(m => m.Id != editedId);
            else
                langs = _unitOfWork.SubCategetoryOffersRepository.GetAll();

            return !langs.Where(m => m.num.ToString() == num).Any();
        }
    }
}
