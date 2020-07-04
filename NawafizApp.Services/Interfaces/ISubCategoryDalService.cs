using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface ISubCategoryDalService
    {
        int addSubCategoryDal(SubCategoryDalDto dto);
        bool deleteSubCategoryDal(int id);
        List<SubCategoryDalDto> getAllSubCategoriesDal();
        bool Edit(SubCategoryDalDto dto);
        SubCategoryDalDto GetById(int id);
        SubCategoryDalDto getSubCategoryDalForFullSize(int id);



    }
}
