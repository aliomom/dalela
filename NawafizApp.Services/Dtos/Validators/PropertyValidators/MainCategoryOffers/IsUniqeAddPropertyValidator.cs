using FluentValidation.Validators;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators.PropertyValidators.LanguageValidator
{
  public  class IsUniqeAddPropertyValidator : PropertyValidator
    {
        public readonly IMainCategoryOffersService _MainCategoryOfferService;
        public IsUniqeAddPropertyValidator(IMainCategoryOffersService MainCategoryOfferService)
            : base("رقم التسلسل موجود مسبقا")
        {
            _MainCategoryOfferService = MainCategoryOfferService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            //string email = context.PropertyValue as string;
            MainCategoryOffersDto m = context.Instance as MainCategoryOffersDto;
            return _MainCategoryOfferService.IsCodeUnique(m.num.ToString(), null);
        }
    }
}
