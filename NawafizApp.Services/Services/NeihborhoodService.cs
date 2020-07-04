using NawafizApp.Domain;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos;
using AutoMapper;
using NawafizApp.Domain.Entities;

namespace NawafizApp.Services.Services
{
  public  class NeihborhoodService :INeihborhoodService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NeihborhoodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addNeiborHood(NeihborhoodDto dto)
        {
            Neighborhood n = new Neighborhood();
            n.Id = dto.Id;
            n.ArabicName = dto.ArabicName;
            n.EngName = dto.EngName;
            n.FrenchName = dto.FrenchName;
            n.PersianName = dto.PersianName;
            n.RussName = dto.RussName;
            n.RegionId = dto.RegionId;           
            _unitOfWork.NeighborhoodRepository.Add(n);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteNeiborHood(int neiborhoodId)
        {
            var n = _unitOfWork.NeighborhoodRepository.FindById(neiborhoodId);
            if (n == null)
            {
                return false;
            }

            _unitOfWork.NeighborhoodRepository.Remove(n);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(NeihborhoodDto dto)
        {
            var n = _unitOfWork.NeighborhoodRepository.FindById(dto.Id);
            n.ArabicName = dto.ArabicName;
            n.EngName = dto.EngName;
            n.FrenchName = dto.FrenchName;
            n.PersianName = dto.PersianName;
            n.RussName = dto.RussName;
            if (dto.RegionId!=0)
            {
                n.RegionId = dto.RegionId;
            }
            _unitOfWork.NeighborhoodRepository.Update(n);
            _unitOfWork.SaveChanges();
            return true;

            throw new NotImplementedException();
        }

        public List<NeihborhoodDto> getAllNeiborHood()
        {
            var list = Mapper.Map<List<Neighborhood>, List<NeihborhoodDto>>(_unitOfWork.NeighborhoodRepository.GetAll().ToList());
            foreach (var item in list)
            {
                item.regionAName = _unitOfWork.RegionRepository.FindById(item.RegionId).ArabicName;
                item.regionEName = _unitOfWork.RegionRepository.FindById(item.RegionId).EngName;
                item.regionFName = _unitOfWork.RegionRepository.FindById(item.RegionId).FrenchName;
                item.regionPName = _unitOfWork.RegionRepository.FindById(item.RegionId).PersianName;
                item.regionRName = _unitOfWork.RegionRepository.FindById(item.RegionId).RussName;
                item.stateId = _unitOfWork.RegionRepository.FindById(item.RegionId).State.Id;        
                item.statename = _unitOfWork.RegionRepository.FindById(item.RegionId).State.ArabicName;
            }
            return list;
        }

        public List<NeihborhoodDto> getAllNeihborhoodsByRegion(int RegionId)
        {
            var m = _unitOfWork.NeighborhoodRepository.GetAll().Where(x => x.RegionId == RegionId).ToList();
            return Mapper.Map<List<Neighborhood>, List<NeihborhoodDto>>(m);

        }

        public NeihborhoodDto GetById(int id)
        {
            var list = _unitOfWork.NeighborhoodRepository.FindById(id);
            return Mapper.Map<Neighborhood, NeihborhoodDto>(list);
        }
    }
}
