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
    public class GuideIsExistIdEditUniquePropertyValidator : PropertyValidator
    {
        public readonly IGuideCityService _GuidecityService;
        public GuideIsExistIdEditUniquePropertyValidator(IGuideCityService GuideCityService)
            : base(CityAndTown.Id_failed)
        {
            _GuidecityService = GuideCityService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            // string email = context.PropertyValue as string;
            InputGuideCityDto m = context.Instance as InputGuideCityDto;
            return _GuidecityService.IsExistId(m.Id);
        }
    }
}
