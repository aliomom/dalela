using FluentValidation;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
   public class RegionValidator : AbstractValidator<RegionDto>
    {
        public readonly IRegionService _RegionService;
        public RegionValidator(IRegionService RegionService, IUserService userService)
        {
            _RegionService = RegionService;
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
            RuleFor(m => m.ArabicName).NotEmpty().WithMessage("الاسم العربي مطلوب");
            RuleFor(m => m.StateId).NotEmpty().WithMessage("يجب اختيار المحاقظه");

        }
    }
}
