using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface IGalleryPhotoService
    {
        int addGalleryPhotoDto(GalleryPhotoDto dto);
        GalleryPhotoDto GetById(int id);
        List<GalleryPhotoDto> GetGalleryPhotoDtoforBanch(int bid);
        List<GalleryPhotoDto> getAllGalleryPhotoDto();
        bool deleteGalleryPhotoDto(int BreakId);
        List<GalleryPhotoDto> getAllGalleryPhotoDtobyBranch(int BranchId);
        bool Edit(GalleryPhotoDto dto);
        bool EditbyId(GalleryPhotoDto dto, int id);
        List<BranchDto> getAllBranchfilter(FilterGalleryPhotoDto filter);
    }
}
