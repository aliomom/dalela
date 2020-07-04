using NawafizApp.Services;
using NawafizApp.Web.Models;
using FluentValidation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NawafizApp.Services.Dtos.Validators.PropertyValidators;
using NawafizApp.Web.Models.Validators;
using FluentValidation.Attributes;
using NawafizApp.Web.Models.Validators.LanguageValidator;
using NawafizApp.Services.Dtos.Validators.PropertyValidators.LanguageValidator;
using NawafizApp.Web.Models.Validators.MainCategoryDalValidator;
using NawafizApp.Services.Dtos.Validators.PropertyValidators.MainCategoryDalValidator;


namespace NawafizApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


        



            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize Mapper
            DtoMappings.Initialize();

            //Initialise Bootstrapper
            Bootstrapper.Initialise();

            FluentValidationModelValidatorProvider.Configure(
              provider =>
              {
                  provider.ValidatorFactory = new DependencyResolverModelValidatorFactory();
                
               provider.Add(
                  typeof(IsEmailUniquePropertyValidator),
                  (metadata, context, rule, validator) => new IsEmailUniqueClientPropertyValidator(metadata, context, rule, validator));
                  provider.Add(
                 typeof(IsNumUniqeAddPropertyValidator),
                 (metadata, context, rule, validator) => new IsNumUniqeAddClientPropertyValidator(metadata, context, rule, validator));
                  provider.Add(
                        typeof(IsNumUniqeEditPropertyValidator),
                        (metadata, context, rule, validator) => new IsNumUniqeEditClientPropertyValidator(metadata, context, rule, validator));
                  provider.Add(
                typeof(IsUniqeAddPropertyValidator),
                (metadata, context, rule, validator) => new IsUniqeAddClientPropertyValidator(metadata, context, rule, validator));
                  provider.Add(
                        typeof(IsUniqeEditPropertyValidator),
                        (metadata, context, rule, validator) => new IsUniqeEditClientPropertyValidator(metadata, context, rule, validator));
                  provider.Add(
              typeof(IsSuUniqeAddPropertyValidator),
              (metadata, context, rule, validator) => new IsSuUniqeAddClientPropertyValidator(metadata, context, rule, validator));
                  provider.Add(
                        typeof(IsSuUniqeEditPropertyValidator),
                        (metadata, context, rule, validator) => new IsSuUniqeEditClientPropertyValidator(metadata, context, rule, validator));


                  /// GuideCity ///
                  // provider.Add(
                  //    typeof(GuideIsArabicNameAddUniquePropertyValidator),
                  //    (metadata, context, rule, validator) => new GuideIsArabicNameAddUniqueClientPropertyValidator(metadata, context, rule, validator));
                  // provider.Add(
                  //   typeof(GuideIsEnglishNameAddUniquePropertyValidator),
                  //   (metadata, context, rule, validator) => new GuideIsEnglishNameAddUniqueClientPropertyValidator(metadata, context, rule, validator));
                  // provider.Add(
                  //   typeof(GuideIsArabicNameEditUniquePropertyValidator),
                  //   (metadata, context, rule, validator) => new GuideIsArabicNameEditUniqueClientPropertyValidator(metadata, context, rule, validator));
                  // provider.Add(
                  //  typeof(GuideIsEnglishNameEditUniquePropertyValidator),
                  //  (metadata, context, rule, validator) => new GuideIsEnglishNameEditUniqueClientPropertyValidator(metadata, context, rule, validator));
                  // provider.Add(
                  //typeof(GuideIsExistIdEditUniquePropertyValidator),
                  //(metadata, context, rule, validator) => new GuideIsExistIdEditUniqueClientPropertyValidator(metadata, context, rule, validator));
                  //// provider.Add(
                  //typeof(GuideIsCityIdExistPropertyValidator),
                  //(metadata, context, rule, validator) => new GuideIsCityIdExistClientPropertyValidator(metadata, context, rule, validator));


                  /// GuideTown ///
                  //  provider.Add(
                  // typeof(GuideIsIdExistTownPropertyValidator),
                  // (metadata, context, rule, validator) => new GuideIsIdExistTownClientPropertyValidator(metadata, context, rule, validator));
                  ////  provider.Add(
                  //typeof(GuideIsCityIdExistPropertyValidator),
                  //(metadata, context, rule, validator) => new GuideIsCityIdExistClientPropertyValidator(metadata, context, rule, validator));

                  /// City ///
                  // provider.Add(
                  //    typeof(IsArabicNameAddUniquePropertyValidator),
                  //    (metadata, context, rule, validator) => new IsArabicNameAddUniqueClientPropertyValidator(metadata, context, rule, validator));
                  // provider.Add(
                  //    typeof(IsEnglishNameAddUniquePropertyValidator),
                  //    (metadata, context, rule, validator) => new IsEnglishNameAddUniqueClientPropertyValidator(metadata, context, rule, validator));
                  // provider.Add(
                  // typeof(IsArabicNameEditUniquePropertyValidator),
                  // (metadata, context, rule, validator) => new IsArabicNameEditUniqueClientPropertyValidator(metadata, context, rule, validator));
                  // provider.Add(
                  // typeof(IsEnglishNameEditUniquePropertyValidator),
                  // (metadata, context, rule, validator) => new IsEnglishNameEditUniqueClientPropertyValidator(metadata, context, rule, validator));
                  // provider.Add(
                  // typeof(IsExistIdEditUniquePropertyValidator),
                  //(metadata, context, rule, validator) => new IsExistIdEditUniqueClientPropertyValidator(metadata, context, rule, validator));


                  /// Town /// 
                  //provider.Add(
                  // typeof(IsCityIdExistPropertyValidator),
                  //(metadata, context, rule, validator) => new IsCityIdExistClientPropertyValidator(metadata, context, rule, validator));
                  //  provider.Add(
                  // typeof(IsIdExistTownPropertyValidator),
                  //(metadata, context, rule, validator) => new IsIdExistTownClientPropertyValidator(metadata, context, rule, validator));
                  //  provider.Add(
                  // typeof(IsPlaceIdUniqueAddPropertyValidator),
                  //(metadata, context, rule, validator) => new IsPlaceIdUniqueAddClientPropertyValidator(metadata, context, rule, validator));

                  //   provider.Add(
                  // typeof(IsPlaceIdUniqueEditPropertyValidator),
                  //(metadata, context, rule, validator) => new IsPlaceIdUniqueEditClientPropertyValidator(metadata, context, rule, validator));


                  /// Classify ///


              });
            
           


        }
    }
}
