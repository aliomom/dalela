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
    public class IsCodeUniqueAddPropertyValidator : PropertyValidator
    {
        public readonly ILanguageService _languageService;
        public IsCodeUniqueAddPropertyValidator(ILanguageService languageService)
            : base("كود اللغة موجود مسبقاً، يرجى إعادة الإدخال")
        {
            _languageService = languageService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            //string email = context.PropertyValue as string;
            LanguageDto m = context.Instance as LanguageDto;
            return _languageService.IsCodeUnique(m.Code, null);
        }
    }
}
