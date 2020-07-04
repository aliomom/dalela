using FluentValidation.Validators;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators.PropertyValidators.LanguageValidator
{
  public  class IsNumUniqeAddPropertyValidator : PropertyValidator
    {
        public readonly IMainCategoryDalService _MainCategoryDalService;
        public IsNumUniqeAddPropertyValidator(IMainCategoryDalService MainCategoryDalService)
            : base("رقم التسلسل موجود مسبقا")
        {
            _MainCategoryDalService = MainCategoryDalService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            //string email = context.PropertyValue as string;
            MainCategoryDalDto m = context.Instance as MainCategoryDalDto;
            return _MainCategoryDalService.IsCodeUnique(m.num.ToString(), null);
        }
    }
}
