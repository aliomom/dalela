using NawafizApp.Services.Interfaces;
using FluentValidation.Validators;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators.PropertyValidators
{
    public class IsLanguageExistEditPropertyValidator : PropertyValidator
    {
        public readonly ILanguageService _languageService;
        public IsLanguageExistEditPropertyValidator(ILanguageService languageService)
            : base("اللغة غير موجودة")
        {
            _languageService = languageService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            //string email = context.PropertyValue as string;
            LanguageDto m = context.Instance as LanguageDto;
            if (_languageService.GetById(m.Id) == null)
                return false;
            else
                return true;
        }
    }
}
