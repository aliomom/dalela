using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
  public  interface IMainCategoryDalService
    {
        int addMainCategoryDal(MainCategoryDalDto dto);
        bool deleteMainCategoryDal(int id);
        bool Edit(MainCategoryDalDto dto);
        MainCategoryDalDto GetById(int id);
        List<MainCategoryDalDto> getMainCategoryDal();
        MainCategoryDalDto getMainCategoryDalForFullSize(int id);
        bool IsCodeUnique(string num, int? editedId);

    }
}
