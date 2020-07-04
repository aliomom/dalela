using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
 public   interface IFollowerService
    {
        List<FollowerDto> getAllFollowers();
    }
}
