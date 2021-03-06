﻿using NawafizApp.Services.Interfaces;
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
    public class GuideIsArabicNameEditUniquePropertyValidator : PropertyValidator
    {
        public readonly IGuideCityService _GuidecityService;
        public GuideIsArabicNameEditUniquePropertyValidator(IGuideCityService GuideCityService)
            : base(CityAndTown.IsNameUnique_ValidatorError)
        {
            _GuidecityService = GuideCityService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            // string email = context.PropertyValue as string;
            InputGuideCityDto m = context.Instance as InputGuideCityDto;
            var c= _GuidecityService.IsNameUnique(m.ArabicCityName, m.Id);
            return c;
        }
    }
}
