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
   public class GalleryPhotoService: IGalleryPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GalleryPhotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int addGalleryPhotoDto(GalleryPhotoDto dto)
        {
            GalleryPhoto r = new GalleryPhoto();
            r.Id = dto.Id;
            r.photo = dto.photo;
            r.BranchId = dto.BranchId;
            _unitOfWork.GalleryPhotoRepository.Add(r);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }

        public bool deleteGalleryPhotoDto(int id)
        {
            var i = _unitOfWork.GalleryPhotoRepository.FindById(id);
            if (i == null) return false;
            _unitOfWork.GalleryPhotoRepository.Remove(i);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(GalleryPhotoDto dto)
        {
            var model = Mapper.Map<GalleryPhotoDto, GalleryPhoto>(dto);
            _unitOfWork.GalleryPhotoRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool EditbyId(GalleryPhotoDto dto,int id)
        {
            var model = _unitOfWork.GalleryPhotoRepository.FindById(id);
            if (dto.photo!=null)
            {
                model.photo = dto.photo;
             
            }
            model.BranchId = dto.BranchId;
            _unitOfWork.GalleryPhotoRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }
        public List<GalleryPhotoDto> getAllGalleryPhotoDto()
        {
            var list = Mapper.Map<List<GalleryPhoto>, List<GalleryPhotoDto>>(_unitOfWork.GalleryPhotoRepository.GetAll().ToList());
            foreach (var item in list)
            {
                item.branchName = _unitOfWork.GalleryPhotoRepository.FindById(item.BranchId).Branch.branchArabicName;
            }
            return list;
        }

        public List<BranchDto> getAllBranchfilter(FilterGalleryPhotoDto filter)
        {
          var list= Mapper.Map < List<Branch>, List< BranchDto >> (_unitOfWork.BranchRepository.GetAll());
            List<BranchDto> listres = new List<BranchDto>();
            if (filter==null)
            {
                return list;
            }
            if (!String.IsNullOrEmpty(filter.Branchname))
            {
                list = list.Where(x => x.branchArabicName.Contains(filter.Branchname)).ToList();
            }
            if (filter.branchId>0)
            {
                list = list.Where(x => x.Id==filter.branchId).ToList();
            }
          
            return list;
        }
        public List<GalleryPhotoDto> getAllGalleryPhotoDtobyBranch(int BranchId)
        {
            return Mapper.Map<List<GalleryPhoto>, List<GalleryPhotoDto>>(_unitOfWork.GalleryPhotoRepository.FindBy(x => x.BranchId == BranchId));
        }

        public GalleryPhotoDto GetById(int id)
        {
            var model = _unitOfWork.GalleryPhotoRepository.FindById(id);
            return Mapper.Map<GalleryPhoto, GalleryPhotoDto>(model);
        }

        public List<GalleryPhotoDto> GetGalleryPhotoDtoforBanch(int bid)
        {
       
            var model = Mapper.Map < List<GalleryPhoto>, List< GalleryPhotoDto >>(_unitOfWork.GalleryPhotoRepository.GetAll().Where(x => x.BranchId == bid).ToList());
            foreach (var item in model)
            {
                item.branchName = _unitOfWork.BranchRepository.FindById(bid).branchArabicName;
            }
            return model;
        
        }
    }
}
