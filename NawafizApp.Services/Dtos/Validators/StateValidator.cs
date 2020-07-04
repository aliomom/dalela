using FluentValidation;
using NawafizApp.Services.Dtos.Validators.PropertyValidators;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
  public  class StateValidator: AbstractValidator<StateDto>
    {
        public readonly IStateService _StateService;
        public StateValidator(IStateService stateService, IUserService userService)
        {
            _StateService = stateService;
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
     
        }
    }
}
