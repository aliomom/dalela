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
    public class InputGuideTownValidator : AbstractValidator<InputGuideTownDto>
    {

        public readonly IGuideTownService _IGuideTownService;
        public InputGuideTownValidator(IGuideTownService GuideTownService)
            {
            _IGuideTownService = GuideTownService;

            RuleSet("AddGuideTown", () =>
               {
                   RuleFor(m => m.CityId).SetValidator(new GuideIsCityIdExistPropertyValidator(_IGuideTownService));
                   
                  
                   //Custom(m =>
                   //{
                   //    return !_ITownService.IsCityIdExist(m.CityId)
                   //        ? new ValidationFailure("CityId", CityAndTown.CityIdNotExist)
                   //        : null;
                   //});
                   CommonRules();

               });



            RuleSet("EditGuideTown", () =>
            {
                //Custom(m =>
                //{
                //    return !_ITownService.IsCityIdExist(m.CityId)
                //        ? new ValidationFailure("CityId", CityAndTown.CityIdNotExist)
                //        : null;
                //});
                RuleFor(m => m.Id).SetValidator(new GuideIsIdExistTownPropertyValidator(_IGuideTownService));
              
                //Custom(m =>
                //{
                //    return !_ITownService.IsIdExist(m.Id)
                //        ? new ValidationFailure("Id", CityAndTown.Id_failed)
                //        : null;
                //});

                CommonRules();
            });

                CommonRules();
            }

            private void CommonRules()
            {
                RuleFor(m => m.ArabicTownName).NotEmpty().WithMessage(CityAndTown.TownNameRequired).Length(0,40).WithMessage(CityAndTown.NameUnacceptable);
                RuleFor(m => m.EnglishTownName).NotEmpty().WithMessage(CityAndTown.TownNameRequired).Length(0, 40).WithMessage(CityAndTown.NameUnacceptable);
                RuleFor(m => m.CityId).NotEmpty().WithMessage(CityAndTown.CityIdRequired);

                RuleFor(m => m.CityId).SetValidator(new GuideIsCityIdExistPropertyValidator(_IGuideTownService));
        }

        }
    }

