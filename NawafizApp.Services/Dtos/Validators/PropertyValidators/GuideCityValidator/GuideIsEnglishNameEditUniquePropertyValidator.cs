using NawafizApp.Services.Interfaces;
using FluentValidation.Validators;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Common.Resources;

namespace NawafizApp.Services.Dtos.Validators.PropertyValidators
{
    public class GuideIsEnglishNameEditUniquePropertyValidator : PropertyValidator
    {
        public readonly IGuideCityService _GuidecityService;
        public GuideIsEnglishNameEditUniquePropertyValidator(IGuideCityService GuideCityService)
            : base(CityAndTown.IsNameUnique_ValidatorError)
        {
            _GuidecityService = GuideCityService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            // string email = context.PropertyValue as string;
            InputGuideCityDto m = context.Instance as InputGuideCityDto;
            return _GuidecityService.IsNameUnique(m.EnglishCityName,m.Id);
        }
    }
}
