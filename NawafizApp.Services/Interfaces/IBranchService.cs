using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface IBranchService
    {
        List<BranchDto> getAllBranchsByNeihborhoods(int NeihborhoodId);
        int addBranch(BranchDto dto);
        List<BranchDto> getAllBranch();

        bool deleteBranch(int BranchId);
        List<BranchDto> getAllBranchbyShopdalid(int? id);
        bool Edit(BranchDto dto);
        BranchDto GetById(int id);
    }
}
