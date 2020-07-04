using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface IBranchAndShopDalService
    {
        int AddBranchAndShopDal(BranchAndShopDalDto dto);
        List<BranchAndShopDalDto> getAllBranchAndShopDal();

        bool deleteBranchAndShopDalDto(int ShopDalId,int BId);

        bool Edit(BranchAndShopDalDto dto);
        BranchAndShopDalDto GetById(int id, int bid);
        BranchAndShopDalDto getofferForFullSize(int id, int ShId);
    }
}
