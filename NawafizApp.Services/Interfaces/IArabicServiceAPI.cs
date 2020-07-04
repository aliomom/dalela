using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
    public interface IArabicServiceAPI
    {
        List<APIMainCategoryDtoAr> getAllArabicMainCategories(string slug);
        List<APISubCategoryDtoAr> getAllSubCategoriesByMainCategory(int MainCatId,string slug);
        APIShopWithBranchesDtoAr getbranchById(int id,string slug);
        List<APIOffersSubCategiesDtoAr> getAllOffersSubCategories(string slug);
        APIOfferDtoAr getOfferById(int id, bool isAdminOffer , string slug);
        List<APIStateDtoArabic> getAllStates(string slug );
        List<APIRegionDtoArabic> getAllRegions(int stateId , string slug);
        List<APIShopsDisplayDtoAr> getShopsBySubCat(int SubCatId, int? stateId, int? regionId,string slug);
        List<APIDisplayOffersOfSubCatDto> getoffersBySubCat(int subcat, bool isAdminOffer, string slug);
    }
}
