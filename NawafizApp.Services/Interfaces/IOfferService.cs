using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
  public  interface IOfferService
    {
        List<OfferDto> getAllOffersBysubcat(int SubId);
        int addOffer(OfferDto dto);
        List<OfferDto> getAllOffers();

        bool deleteOffer(int OfferId);

        bool Edit(OfferDto dto);
        OfferDto GetById(int id);
        OfferDto getofferForFullSize(int id);
    }
}
