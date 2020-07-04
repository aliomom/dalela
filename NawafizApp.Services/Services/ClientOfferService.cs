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
   public class ClientOfferService: IClientOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientOfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addClientOffer(ClientOfferDto dto)
        {
            ClientOffer c = new ClientOffer();
            c.Id = dto.Id;
            c.title = dto.title;
            c.photo = dto.photo;
            c.details = dto.details;
            c.Start = dto.Start;
            c.end = dto.end;
            c.Timeofpuplishing = dto.Timeofpuplishing;
            c.Dateofpuplishing =dto.Dateofpuplishing ;
            c.BranchId = dto.BranchId;
           _unitOfWork.ClientOfferRepository.Add(c);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteClientOffer(int ClientOfferId)
        {
            var i = _unitOfWork.ClientOfferRepository.FindById(ClientOfferId);
            if (i == null) return false;
            _unitOfWork.ClientOfferRepository.Remove(i);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(ClientOfferDto dto)
        {
            var model = Mapper.Map<ClientOfferDto, ClientOffer>(dto);
            _unitOfWork.ClientOfferRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<ClientOfferDto> getAllClientOffer()
        {
            var list = Mapper.Map<List<ClientOffer>, List<ClientOfferDto>>(_unitOfWork.ClientOfferRepository.GetAll().ToList());
            foreach (var item in list)
            {
                item.BranchName = _unitOfWork.BranchRepository.FindById(item.BranchId).branchArabicName;
            }
            return list;
        }

        public List<ClientOfferDto> getAllClientOffersByBranch(int BranchId)
        {
            return Mapper.Map<List<ClientOffer>, List<ClientOfferDto>>(_unitOfWork.ClientOfferRepository.FindBy(x => x.BranchId == BranchId));
        }

        public ClientOfferDto GetById(int id)
        {
            var model = _unitOfWork.ClientOfferRepository.FindById(id);
            return Mapper.Map<ClientOffer, ClientOfferDto>(model);
        }
    }
}
