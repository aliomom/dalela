using AutoMapper;
using NawafizApp.Domain;
using NawafizApp.Domain.Entities;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Services
{
   public class BreakService:IBreakService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BreakService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addBreak(BreakDto dto)
        {
            Break r = new Break();
            r.Id = dto.Id;
            r.start = dto.start;
            r.end = dto.end;
            r.BranchId = dto.BranchId;
                      
            _unitOfWork.BreakRepository.Add(r);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteBreak(int BreakId)
        {
            var i = _unitOfWork.BreakRepository.FindById(BreakId);
            if (i == null) return false;
            _unitOfWork.BreakRepository.Remove(i);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(BreakDto dto,int id)
        {
            var r = _unitOfWork.BreakRepository.FindById(id);
            if (dto.start!=null)
            {
                r.start = dto.start;
            }
            if (dto.end!=null)
            {
                r.end = dto.end;
            }
           
            r.BranchId = dto.BranchId;
            _unitOfWork.BreakRepository.Update(r);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<BreakDto> getAllBreakbyBranch(int BranchId)
        {
        
            var list = Mapper.Map<List<Break>, List<BreakDto>>(_unitOfWork.BreakRepository.FindBy(x => x.BranchId == BranchId));
            foreach (var item in list)
            {
                item.BranchName = _unitOfWork.BranchRepository.FindById(item.BranchId).branchArabicName;
            }
            return list;
        }

        public List<BreakDto> getAllBreaks()
        {
            var list = Mapper.Map<List<Break>, List<BreakDto>>(_unitOfWork.BreakRepository.GetAll().ToList());
            foreach (var item in list)
            {
                item.BranchName = _unitOfWork.BranchRepository.FindById(item.BranchId).branchArabicName;               
            }
            return list;
        }

        public BreakDto GetById(int id)
        {
            var model = _unitOfWork.BreakRepository.FindById(id);
            
            return Mapper.Map<Break, BreakDto>(model);
        }
    }
}
