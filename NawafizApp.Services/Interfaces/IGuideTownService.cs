using NawafizApp.Common;
using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
    public interface IGuideTownService
    {
        #region InputGuideTownDto

        int? Add(LanguageHelper Language, InputGuideTownDto dto);
        bool? Edit(LanguageHelper Language, InputGuideTownDto dto);
        bool? Delete(int Id);

        #endregion

        #region GuideTownDto

        GuideTownDto GetGuideTownById(LanguageHelper language, int id);
        GuideCityDto GetGuideCityByTownId(LanguageHelper language, int id);
        List<GuideTownDto> GetAllGuideTowns(LanguageHelper language);

        #endregion

        #region Validator

        bool IsIdExist(int id);
        bool IsCityIdExist(int CityId);
        //bool ISPlaceIdUnique(string ArabicTownName, int CityId, int? editedId);

        #endregion

    }
}
