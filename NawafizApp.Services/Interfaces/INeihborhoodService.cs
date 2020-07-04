using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface INeihborhoodService
    {
        List<NeihborhoodDto> getAllNeihborhoodsByRegion(int RegionId);
        int addNeiborHood(NeihborhoodDto dto);
        List<NeihborhoodDto> getAllNeiborHood();

        bool deleteNeiborHood(int neiborhoodId);

        bool Edit(NeihborhoodDto dto);
        NeihborhoodDto GetById(int id);

    }
}
