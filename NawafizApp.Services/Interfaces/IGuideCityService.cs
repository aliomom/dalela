using NawafizApp.Common;
using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
    public interface IGuideCityService
    {
        #region InputGuideCityDto

        int Add(LanguageHelper Language, InputGuideCityDto dto);
        bool Edit(LanguageHelper Language, InputGuideCityDto dto);
        bool? Delete(int Id);

        #endregion

        #region GuideCityDto
        List<GuideCityDto> GetAllGuideCities(LanguageHelper language);
        GuideCityDto GetGuideCityById(LanguageHelper language, int id);
        #endregion

        #region Validator

        bool IsNameUnique(string name, int? id);

        bool IsExistId(int id);

        #endregion


    }
}
