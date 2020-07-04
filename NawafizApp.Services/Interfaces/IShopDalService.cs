using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
  public  interface IShopDalService
    {
        int addShopDal(ShopDalDto dto);
        ShopDalDto GetById(int id);
        List<ShopDalDto> getAllShopDal();
        List<ShopDalSearchResDto> getAllShopDalfilter(FilterDto filter);
        bool deleteShopDalD(int ShopDalDId);
        List<ShopDalDto> getAllShopDalbysubCategory(int subCategoryId);
        bool Edit(ShopDalDto dto);
    }
}
