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
   public class RegionService : IRegionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public RegionDto GetById(int id)
        {
            var model = _unitOfWork.RegionRepository.FindById(id);
            return Mapper.Map<Region, RegionDto>(model);

        }
        public int addRegion(RegionDto dto)
        {
       
            Region r = new Region();
            r.Id = dto.Id;
            r.ArabicName = dto.ArabicName;
            r.FrenchName = dto.FrenchName;
            r.PersianName = dto.PersianName;
            r.EngName = dto.EngName;
            r.RussName = dto.RussName;
            r.StateId = dto.StateId;
            _unitOfWork.RegionRepository.Add(r);
            _unitOfWork.SaveChanges();
            return dto.Id;
        
    }

        public bool deleteRegion(int regionId)
        {
            var i = _unitOfWork.RegionRepository.FindById(regionId);
            if (i == null) return false;
            _unitOfWork.RegionRepository.Remove(i);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(RegionDto dto)
        {
            var model = Mapper.Map<RegionDto, Region>(dto);
            if (dto.StateId!=0)
            {
                model.StateId = dto.StateId;
            }
            _unitOfWork.RegionRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<RegionDto> getAllRegions()
        {
            var list = Mapper.Map<List<Region>, List<RegionDto>>(_unitOfWork.RegionRepository.GetAll().ToList());
            foreach (var item in list)
            {
                item.stateAname = _unitOfWork.StateRepository.FindById(item.StateId).ArabicName;
                item.stateEname = _unitOfWork.StateRepository.FindById(item.StateId).EngName;
                item.stateFname = _unitOfWork.StateRepository.FindById(item.StateId).FrenchName;
                item.statePname = _unitOfWork.StateRepository.FindById(item.StateId).PersianName;
                item.stateRname = _unitOfWork.StateRepository.FindById(item.StateId).RussName;
            }
            return list;
        }

        public List<RegionDto> getAllRegiosbyState(int stateId)
        {
            return Mapper.Map<List<Region>, List<RegionDto>>(_unitOfWork.RegionRepository.FindBy(x => x.StateId == stateId));
        }
    }
}
