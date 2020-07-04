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
using NawafizApp.Common;

namespace NawafizApp.Services.Services
{
   public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addOffer(OfferDto dto)
        {
            Offer n = new Offer();
            n.Id = dto.Id;
            n.Atitle = dto.Atitle;
            n.Etitle = dto.Etitle;
            n.Ftitle = dto.Ftitle;
            n.Ptitle = dto.Ptitle;
            n.Rtitle = dto.Rtitle;
            n.photo = dto.photo;
            n.photo1 = dto.photo1;
            n.photo2 = dto.photo2;
            n.photo3 = dto.photo3;
            n.phon1 = dto.phon1;
            n.phon2 = dto.phon2;
            n.phon3 = dto.phon3;
            n.phon4 = dto.phon4;
            n.phon5 = dto.phon5;
            n.phon6 = dto.phon6;
            n.email = dto.email;
            n.faceLink = dto.faceLink;
            n.instaLink = dto.instaLink;
            n.Whatsphon = dto.Whatsphon;
            n.Adetails = dto.Adetails;
            n.Edetails = dto.Edetails;
            n.Fdetails = dto.Fdetails;
            n.Pdetails = dto.Pdetails;
            n.Rdetails = dto.Rdetails;
         
            n.Start = dto.Start;
            n.end = dto.end;     
            n.Timeofpuplishing = dto.Timeofpuplishing;
            n.Dateofpuplishing = dto.Dateofpuplishing;
            n.SubCategetoryOffersId = dto.SubCategetoryOffersId;
            _unitOfWork.OfferRepository.Add(n);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteOffer(int OfferId)
        {
            var n = _unitOfWork.OfferRepository.FindById(OfferId);
            if (n == null)
            {
                return false;
            }

            _unitOfWork.OfferRepository.Remove(n);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(OfferDto dto)
        {
            var n = _unitOfWork.OfferRepository.FindById(dto.Id);
            n.Id = dto.Id;
            n.Atitle = dto.Atitle;
            n.Etitle = dto.Etitle;
            n.Ftitle = dto.Ftitle;
            n.Ptitle = dto.Ptitle;
            n.Rtitle = dto.Rtitle;
            if (dto.photo!=null)
            {
                n.photo = dto.photo;
            }
            if (dto.photo1!=null)
            {
                n.photo1 = dto.photo1;
            }
            if (dto.photo2!=null)
            {
                n.photo2 = dto.photo2;
            }
            if (dto.photo3!=null)
            {
                n.photo3 = dto.photo3;
            }
            
            n.phon1 = dto.phon1;
            n.phon2 = dto.phon2;
            n.phon3 = dto.phon3;
            n.phon4 = dto.phon4;
            n.phon5 = dto.phon5;
            n.phon6 = dto.phon6;
            n.email = dto.email;
            n.faceLink = dto.faceLink;
            n.instaLink = dto.instaLink;
            n.Whatsphon = dto.Whatsphon;
            n.Adetails = dto.Adetails;
            n.Edetails = dto.Edetails;
            n.Fdetails = dto.Fdetails;
            n.Pdetails = dto.Pdetails;
            n.Rdetails = dto.Rdetails;
            n.Start = dto.Start;
            n.end = dto.end;
            n.Timeofpuplishing = dto.Timeofpuplishing;
            n.Dateofpuplishing = dto.Dateofpuplishing;
            n.SubCategetoryOffersId = dto.SubCategetoryOffersId;

            _unitOfWork.OfferRepository.Update(n);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<OfferDto> getAllOffers()
        {
            var list = Mapper.Map<List<Offer>, List<OfferDto>>(_unitOfWork.OfferRepository.GetAll().ToList());
            foreach (var item in list)
            {
                item.SubCategetoryOffersName = _unitOfWork.SubCategetoryOffersRepository.FindById(item.SubCategetoryOffersId).ArabicName;
                item.MainCategetoryOffersId = _unitOfWork.SubCategetoryOffersRepository.FindById(item.SubCategetoryOffersId).MainCategoryOffersId;
                item.MainCategetoryOffersName = _unitOfWork.MainCategoryOffersRepository.FindById(item.MainCategetoryOffersId).ArabicName;
               
        
            }
            return list;
        }
     
        public List<OfferDto> getAllOffersBysubcat(int subId)
        {
            var m = _unitOfWork.OfferRepository.GetAll().Where(x => x.SubCategetoryOffersId == subId).ToList();
            return Mapper.Map<List<Offer>, List<OfferDto>>(m);
        }

        public OfferDto GetById(int id)
        {
            var list = _unitOfWork.OfferRepository.FindById(id);
            list.Dateofpuplishing = _unitOfWork.OfferRepository.FindById(id).Dateofpuplishing;
            list.Timeofpuplishing = _unitOfWork.OfferRepository.FindById(id).Timeofpuplishing;
            list.Atitle= _unitOfWork.OfferRepository.FindById(id).Atitle;
            list.Etitle=_unitOfWork.OfferRepository.FindById(id).Etitle;
            list.Ptitle = _unitOfWork.OfferRepository.FindById(id).Ftitle;
            list.Ftitle = _unitOfWork.OfferRepository.FindById(id).Ptitle;
            list.Rtitle = _unitOfWork.OfferRepository.FindById(id).Rtitle;
            list.Adetails = _unitOfWork.OfferRepository.FindById(id).Adetails;
            list.Edetails = _unitOfWork.OfferRepository.FindById(id).Edetails;
            list.Fdetails = _unitOfWork.OfferRepository.FindById(id).Fdetails;
            list.Pdetails = _unitOfWork.OfferRepository.FindById(id).Pdetails;
            list.Rdetails = _unitOfWork.OfferRepository.FindById(id).Rdetails;
            list.phon1 = _unitOfWork.OfferRepository.FindById(id).phon1;
            list.phon2 = _unitOfWork.OfferRepository.FindById(id).phon2;
            list.phon3 = _unitOfWork.OfferRepository.FindById(id).phon3;
            list.phon4 = _unitOfWork.OfferRepository.FindById(id).phon4;
            list.phon5 = _unitOfWork.OfferRepository.FindById(id).phon5;
            list.faceLink = _unitOfWork.OfferRepository.FindById(id).faceLink;
            list.instaLink = _unitOfWork.OfferRepository.FindById(id).instaLink;
            list.Whatsphon = _unitOfWork.OfferRepository.FindById(id).Whatsphon;
            list.Start = _unitOfWork.OfferRepository.FindById(id).Start;
            list.end= _unitOfWork.OfferRepository.FindById(id).end;
            list.SubCategetoryOffersId = _unitOfWork.OfferRepository.FindById(id).SubCategetoryOffersId;
      


            return Mapper.Map<Offer, OfferDto>(list);
        }

        public OfferDto getofferForFullSize(int id)
        {
            OfferDto dto = new OfferDto();
            Offer main = _unitOfWork.OfferRepository.FindById(id);
            dto.Id = dto.Id;
            dto.Atitle = main.Atitle;
            dto.Etitle = main.Etitle;
            dto.Ftitle = main.Ftitle;
            dto.Ptitle = main.Ptitle;
            dto.Rtitle = main.Rtitle;
            dto.photo = main.photo;
            dto.photo1 = main.photo1;
            dto.photo2 = main.photo2;
            dto.photo3 = main.photo3;
            dto.phon1 = main.phon1;
            dto.phon2 = main.phon2;
            dto.phon3 = main.phon3;
            dto.phon4 = main.phon4;
            dto.phon5 = main.phon5;
            dto.phon6 = main.phon6;
            dto.faceLink = main.faceLink;
            dto.instaLink = main.instaLink;
            dto.Whatsphon = main.Whatsphon;
            dto.Adetails = main.Adetails;
            dto.Edetails = main.Edetails;
            dto.Fdetails = main.Fdetails;
            dto.Pdetails = main.Pdetails;
            dto.Rdetails = main.Rdetails;
            dto.Start = main.Start;
            dto.end = main.end;
            dto.Timeofpuplishing = main.Timeofpuplishing;
            dto.Dateofpuplishing = main.Dateofpuplishing;
          
            dto.SubCategetoryOffersName = main.SubCategetoryOffers.ArabicName;
            return dto;
        }
    }
}
