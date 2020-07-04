using FluentValidation;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
  public  class SubCategoryDalValidator : AbstractValidator<SubCategoryDalDto>
    {
        public readonly ISubCategoryDalService _SubCategoryDalService;
        public SubCategoryDalValidator(ISubCategoryDalService SubCategoryDalService, IUserService userService)
        {
            _SubCategoryDalService = SubCategoryDalService;
            RuleSet("Add", () =>
            {
                //RuleFor(m => m.num).SetValidator(new IsNumUniqeAddPropertyValidator(_MainCategoryDalService));
                CommonRules();
            });
            RuleSet("Edit", () =>
            {

                //RuleFor(m => m.num).SetValidator(new IsNumUniqeEditPropertyValidator(_MainCategoryDalService));
                CommonRules();
            });

            CommonRules();
        }

        private void CommonRules()
        {
            RuleFor(m => m.ArabicName).NotEmpty().WithMessage("الاسم العربي مطلوب");
            RuleFor(m => m.icon).NotEmpty().WithMessage("يجب ادخال صوره رقميه ");      
            RuleFor(m => m.MainCategoryDalId).NotEmpty().WithMessage("يجب اختيار الفئة الرئيسيه ");
        }
    }
}
