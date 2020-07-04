using FluentValidation;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
   public class OfferValidator : AbstractValidator<OfferDto>
    {
        public readonly IOfferService _OffferService;
        public OfferValidator(IOfferService OffferService, IUserService userService)
        {
            _OffferService = OffferService;
            RuleSet("Add", () =>
            {

                CommonRules();
            });
            RuleSet("Edit", () =>
            {
                CommonRules();
            });

            CommonRules();
        }

        private void CommonRules()
        {
            RuleFor(m => m.Atitle).NotEmpty().WithMessage("العنوان العربي مطلوب");
            RuleFor(m => m.Adetails).NotEmpty().WithMessage("التفاصيل العربيه مطلوبه");
         
            RuleFor(m => m.MainCategetoryOffersId).NotEmpty().WithMessage("يجب اختيار الفئة الرئيسية");
            RuleFor(m => m.SubCategetoryOffersId).NotEmpty().WithMessage("يجب اختيار الفئة الفرعيه");
        }
    }
}
