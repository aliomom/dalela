using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface IStateService
    {
        int Add(StateDto dto);
        bool Edit(StateDto dto);

        StateDto GetById(int id);
        List<StateDto> All();
        bool RemoveState(int stateId);
    }
}
