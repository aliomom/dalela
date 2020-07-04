using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface IMainCategoryOffersService
    {
        int addMainCategoryOffers(MainCategoryOffersDto dto);
        bool deleteMainCategoryOffers(int id);
        bool Edit(MainCategoryOffersDto dto);
        MainCategoryOffersDto GetById(int id);
        List<MainCategoryOffersDto> getMainCategoryOffers();
        bool IsCodeUnique(string num, int? editedId);


    }
}
