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
   public class SubCategetoryOffersValidator : AbstractValidator<SubCategetoryOffersDto>
    {
        public readonly ISubCategetoryOffersService _SubCategetoryOffersService;
        public SubCategetoryOffersValidator(ISubCategetoryOffersService SubCategetoryOffersService, IUserService userService)
        {
            _SubCategetoryOffersService = SubCategetoryOffersService;
            RuleSet("AddS", () =>
            {
                RuleFor(m => m.num).SetValidator(new IsSuUniqeAddPropertyValidator(_SubCategetoryOffersService));
                CommonRules();
            });
            RuleSet("EditS", () =>
            {

                RuleFor(m => m.num).SetValidator(new IsSuUniqeEditPropertyValidator(_SubCategetoryOffersService));
                CommonRules();
            });

            CommonRules();
        }

        private void CommonRules()
        {
            RuleFor(m => m.ArabicName).NotEmpty().WithMessage("الاسم العربي مطلوب");
            //RuleFor(m => m.icon).NotEmpty().WithMessage("يجب ادخال صوره رقميه ");
            RuleFor(m => m.num).NotEmpty().WithMessage("يجب ادخال رقم التسلسل ").GreaterThanOrEqualTo(1).WithMessage("ادخل قيمة موجبه او مغايرة للصفر");
            RuleFor(m => m.MainCategoryOffersId).NotEmpty().WithMessage("يجب اختيار الفئة الرئيسيه ");
        }
    }
}
