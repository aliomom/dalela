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
   public class MainCategoryOffersValidator : AbstractValidator<MainCategoryOffersDto>
    {
        public readonly IMainCategoryOffersService _MainCategoryOffersService;
        public MainCategoryOffersValidator(IMainCategoryOffersService MainCategoryOfferService, IUserService userService)
        {
            _MainCategoryOffersService = MainCategoryOfferService;
            RuleSet("AddM", () =>
            {
                RuleFor(m => m.num).SetValidator(new IsUniqeAddPropertyValidator(_MainCategoryOffersService));
                CommonRules();
            });
            RuleSet("EditM", () =>
            {

                RuleFor(m => m.num).SetValidator(new IsUniqeEditPropertyValidator(_MainCategoryOffersService));
                CommonRules();
            });

            CommonRules();
        }

        private void CommonRules()
        {
            RuleFor(m => m.ArabicName).NotEmpty().WithMessage("الاسم العربي مطلوب");
            //RuleFor(m => m.icon).NotEmpty().WithMessage("يجب ادخال صوره رقميه ");
            RuleFor(m => m.num).NotEmpty().WithMessage("يجب ادخال رقم التسلسل ").GreaterThanOrEqualTo(1).WithMessage("ادخل قيمة موجبه او مغايرة للصفر");
        }
    }
}
