using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface IBreakService
    {
        int addBreak(BreakDto dto);
        BreakDto GetById(int id);
        List<BreakDto> getAllBreaks();
        bool deleteBreak(int BreakId);
        List<BreakDto> getAllBreakbyBranch(int BranchId);
        bool Edit(BreakDto dto,int id);
    }
}
