using FluentValidation;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
   public class FavouriteValidator : AbstractValidator<FavouriteDto>
    {
        public readonly INotificationService _INotificationService;
        public FavouriteValidator(INotificationService INotificationService, IUserService userService)
        {
            _INotificationService = INotificationService;
            RuleSet("Add", () =>
            {

                CommonRules();
            });
     

            CommonRules();
        }

        private void CommonRules()
        {
            RuleFor(m => m.subCatIds).NotEmpty().WithMessage("الفئة الفرعية العربي مطلوب");

       

        }
    }
}

