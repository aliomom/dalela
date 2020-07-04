using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
  public  interface IRegionService
    {
        int addRegion(RegionDto dto);
        RegionDto GetById(int id);
        List<RegionDto> getAllRegions();
        bool deleteRegion(int regionId);
        List<RegionDto> getAllRegiosbyState(int stateId);
        bool Edit(RegionDto dto);
    }
}
