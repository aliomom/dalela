using NawafizApp.Services.Dtos.Validators.PropertyValidators;
using FluentValidation;
using FluentValidation.Results;
using NawafizApp.Services.Dtos.Validators.PropertyValidators;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public readonly IUserService _userService;
        public RegisterUserValidator(IUserService userService)
        {
            _userService = userService;
            RuleSet("Register", () =>
            {
                CommonRules();
            });
            CommonRules();
        }
        private void CommonRules()
        {
            RuleFor(x => x.username).NotEmpty().WithMessage("الحقل مطلوب");
            RuleFor(x => x.Role).NotEmpty().WithMessage("الحقل مطلوب");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("الحقل مطلوب");
            RuleFor(x => x.ShopId).NotEmpty().WithMessage("الحقل مطلوب");
           
            RuleFor(m => m.Password).NotEmpty().WithMessage("كلمة المرور مطلوبة").Length(6, 25).WithMessage("كلمة المرور مرفوضة");
           RuleFor(m => m.CPassword).NotEmpty().WithMessage("تأكيد كلمة المرور مطلوب").Equal(x => x.Password).WithMessage("كلمة المرور وتأكيدها غير متطابقان");
            //RuleFor(m => m.FullName).NotEmpty().WithMessage("الاسم مطلaaوب");

            //RuleFor(m => m.Email).SetValidator(new IsEmailUniquePropertyValidator(_userService));
        }
    }
}
