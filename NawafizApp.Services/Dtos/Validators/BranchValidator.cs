using FluentValidation;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
 public   class BranchValidator : AbstractValidator<BranchDto>
    {
        public readonly IBranchService _BranchService;
        public BranchValidator(IBranchService BranchService, IUserService userService)
        {
            _BranchService = BranchService;
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
            RuleFor(m => m.branchArabicName).NotEmpty().WithMessage("الاسم العربي مطلوب");
            RuleFor(m => m.email1).Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$").WithMessage("ادخل ايميل صحيح");
            RuleFor(m => m.email2).Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$").WithMessage("ادخل ايميل صحيح");

            RuleFor(m => m.instaLink).Matches(@"https?:\/\/(www\.)?instagram\.com\/([A-Za-z0-9_](?:(?:[A-Za-z0-9_]|(?:\.(?!\.))){0,28}(?:[A-Za-z0-9_]))?)").WithMessage("ادخل رابط صحيح");
            RuleFor(m => m.facebookLink).Matches("^https?://(www|m).facebook.com/(.*)$").WithMessage("ادخل رابط صحيح");
            RuleFor(m => m.sstr).NotEmpty().WithMessage("وقت بداية الدوام مطلوب ");
            RuleFor(m => m.estr).NotEmpty().WithMessage("وقت نهاية الدوام مطلوب ");
            RuleFor(m => m.stateId).NotEmpty().WithMessage("اختر المحافظة ");
            RuleFor(m => m.RegionId).NotEmpty().WithMessage("اختر المنطقة ");
            RuleFor(m => m.NeighborhoodId).NotEmpty().WithMessage("اختر الحي ");
        }
    }
}
