using FluentValidation.Validators;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators.PropertyValidators.LanguageValidator
{
  public  class IsSuUniqeAddPropertyValidator : PropertyValidator
    {
        public readonly ISubCategetoryOffersService _SubCategetoryOffersService;
        public IsSuUniqeAddPropertyValidator(ISubCategetoryOffersService SubCategetoryOffersService)
            : base("رقم التسلسل موجود مسبقا")
        {
            _SubCategetoryOffersService = SubCategetoryOffersService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            //string email = context.PropertyValue as string;
            SubCategetoryOffersDto m = context.Instance as SubCategetoryOffersDto;
            return _SubCategetoryOffersService.IsCodeUnique(m.num.ToString(), null);
        }
    }
}
