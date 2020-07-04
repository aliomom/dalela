using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
  public  interface ISubCategetoryOffersService
    {
        int addSubCategetoryOffers(SubCategetoryOffersDto dto);
        bool deleteSubCategetoryOffers(int id);
        List<SubCategetoryOffersDto> getAllSubCategetoryOffers();
        bool Edit(SubCategetoryOffersDto dto);
        SubCategetoryOffersDto GetById(int id);
        List<SubCategetoryOffersDto> getAllSubCategoriesByMainCatrgory(int MainCatId);
        bool IsCodeUnique(string num, int? editedId);
    }
}
