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
    public class GuideIsCityIdExistPropertyValidator : PropertyValidator
    {
        public readonly IGuideTownService _IGuideTownService;
        public GuideIsCityIdExistPropertyValidator(IGuideTownService GuideTownService)
            : base(CityAndTown.CityIdNotExist)
        {
            _IGuideTownService = GuideTownService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            // string email = context.PropertyValue as string;

            InputGuideTownDto m = context.Instance as InputGuideTownDto;
           
           return _IGuideTownService.IsCityIdExist(m.CityId);
           
              
        }
    }
}
