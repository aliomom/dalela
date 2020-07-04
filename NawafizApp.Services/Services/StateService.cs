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
 public   class StateService : IStateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int Add(StateDto dto)
        {
            var model = Mapper.Map<StateDto, State>(dto);
            _unitOfWork.StateRepository.Add(model);
            _unitOfWork.SaveChanges();
            return model.Id;
   
        }
        public bool RemoveState(int stateId)
        {
            var i = _unitOfWork.StateRepository.FindById(stateId);
            if (i == null) return false;
            _unitOfWork.StateRepository.Remove(i);
            _unitOfWork.SaveChanges();
            return true;

        }


        public List<StateDto> All()
        {
            var list = _unitOfWork.StateRepository.GetAll();
            return Mapper.Map<List<State>, List<StateDto>>(list);
        }

        public bool Edit(StateDto dto)
        {
            var model = Mapper.Map<StateDto, State>(dto);
            _unitOfWork.StateRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }

        public StateDto GetById(int id)
        {
            var model = _unitOfWork.StateRepository.FindById(id);
            return Mapper.Map<State, StateDto>(model);
           
        }

       
    }
}
