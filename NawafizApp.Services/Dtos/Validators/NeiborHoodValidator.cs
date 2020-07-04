using FluentValidation;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
   public class NeiborHoodValidator : AbstractValidator<NeihborhoodDto>
    {
        public readonly INeihborhoodService _NeiborHoodService;
        public NeiborHoodValidator(INeihborhoodService NeiborHoodService, IUserService userService)
        {
            _NeiborHoodService = NeiborHoodService;
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
            RuleFor(m => m.stateId).NotEmpty().WithMessage("يجب اختيار المحافظه");
            RuleFor(m => m.RegionId).NotEmpty().WithMessage("يجب اختيار المنطقه");
        }
    }
}
