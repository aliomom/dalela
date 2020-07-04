using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
   public interface IClientOfferService
    {
        List<ClientOfferDto> getAllClientOffersByBranch(int BranchId);
        int addClientOffer(ClientOfferDto dto);
        List<ClientOfferDto> getAllClientOffer();

        bool deleteClientOffer(int ClientOfferId);

        bool Edit(ClientOfferDto dto);
        ClientOfferDto GetById(int id);

    }
}
