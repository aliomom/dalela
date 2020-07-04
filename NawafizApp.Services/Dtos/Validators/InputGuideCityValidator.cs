using FluentValidation;
using FluentValidation.Results;
using NawafizApp.Services.Interfaces;
using NawafizApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Common.Resources;
using NawafizApp.Services.Dtos.Validators.PropertyValidators;

namespace NawafizApp.Services.Dtos.Validators
{
    public class InputGuideCityValidator : AbstractValidator<InputGuideCityDto>
    {

        public readonly IGuideCityService _lGuideCityService;
        public InputGuideCityValidator(IGuideCityService GuidecityService)
            {
            _lGuideCityService = GuidecityService;

            RuleSet("AddGuideCity", () =>
               {

                   RuleFor(m => m.ArabicCityName).SetValidator(new GuideIsArabicNameAddUniquePropertyValidator(_lGuideCityService));
                   RuleFor(m => m.EnglishCityName).SetValidator(new GuideIsEnglishNameAddUniquePropertyValidator(_lGuideCityService));
                   //Custom(m =>
                   //{
                   //    return !_lCityService.IsNameUnique(m.EnglishCityName, null)
                   //       ? new ValidationFailure("EnglishCityName", CityAndTown.IsNameUnique_ValidatorError)
                   //       : null;
                   //});


                   CommonRules();

               });



            RuleSet("EditGuideCity", () =>
            {
                RuleFor(m => m.ArabicCityName).SetValidator(new GuideIsArabicNameEditUniquePropertyValidator(_lGuideCityService));
                //Custom(m =>
                //{
                //    return !_lCityService.IsNameUnique(m.ArabicCityName, m.Id)
                //       ? new ValidationFailure("ArabicCityName", CityAndTown.IsNameUnique_ValidatorError)
                //       : null;
                //});
                RuleFor(m => m.EnglishCityName).SetValidator(new GuideIsEnglishNameEditUniquePropertyValidator(_lGuideCityService));
                //Custom(m =>
                //{
                //    return !_lCityService.IsNameUnique(m.EnglishCityName, m.Id)
                //       ? new ValidationFailure("EnglishCityName", CityAndTown.IsNameUnique_ValidatorError)
                //       : null;
                //});
                RuleFor(m => m.Id).SetValidator(new GuideIsExistIdEditUniquePropertyValidator(_lGuideCityService));
                //Custom(m =>
                //{
                //    return !_lCityService.IsExistId(m.Id)
                //        ? new ValidationFailure("Id", CityAndTown.Id_failed)
                //        : null;
                //});

                CommonRules();
            });

                CommonRules();
            }

            private void CommonRules()
            {
                RuleFor(m => m.ArabicCityName).NotEmpty().WithMessage(CityAndTown.CityNameRequired).Length(0,40).WithMessage(CityAndTown.NameUnacceptable);
                RuleFor(m => m.EnglishCityName).NotEmpty().WithMessage(CityAndTown.CityNameRequired).Length(0, 40).WithMessage(CityAndTown.NameUnacceptable);
                RuleFor(m => m.Sort).NotEmpty().WithMessage(CityAndTown.City_Sort_Required);
        }

    }
    }

