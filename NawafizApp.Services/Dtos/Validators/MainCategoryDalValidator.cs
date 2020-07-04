using FluentValidation;
using NawafizApp.Services.Dtos.Validators.PropertyValidators.LanguageValidator;
using NawafizApp.Services.Dtos.Validators.PropertyValidators.MainCategoryDalValidator;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
   public class MainCategoryDalValidator : AbstractValidator<MainCategoryDalDto>
    {
        public readonly IMainCategoryDalService _MainCategoryDalService;
        public MainCategoryDalValidator(IMainCategoryDalService MainCategoryDalService, IUserService userService)
        {
            _MainCategoryDalService = MainCategoryDalService;
            RuleSet("Add", () =>
            {
                RuleFor(m => m.num).SetValidator(new IsNumUniqeAddPropertyValidator(_MainCategoryDalService));
                CommonRules();
            });
            RuleSet("Edit", () =>
            {

                RuleFor(m => m.num).SetValidator(new IsNumUniqeEditPropertyValidator(_MainCategoryDalService));
                CommonRules();
            });

            CommonRules();
        }

        private void CommonRules()
        {
            RuleFor(m => m.ArabicName).NotEmpty().WithMessage("الاسم العربي مطلوب");
            RuleFor(m => m.icon).NotEmpty().WithMessage("يجب ادخال صوره رقميه ");
            RuleFor(m => m.num).NotEmpty().WithMessage("يجب ادخال رقم التسلسل ").GreaterThanOrEqualTo(1).WithMessage("ادخل قيمة موجبه او مغايرة للصفر");
        }
    }
}
