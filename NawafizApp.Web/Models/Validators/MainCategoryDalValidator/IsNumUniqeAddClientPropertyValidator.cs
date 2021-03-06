﻿using FluentValidation.Internal;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using NawafizApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NawafizApp.Web.Models.Validators.MainCategoryDalValidator
{
   public  class IsNumUniqeAddClientPropertyValidator : FluentValidationPropertyValidator
    {
        public IsNumUniqeAddClientPropertyValidator(ModelMetadata metadata, ControllerContext controllerContext, PropertyRule rule, IPropertyValidator validator)
            : base(metadata, controllerContext, rule, validator)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (!this.ShouldGenerateClientSideRules())
                yield break;
            var formatter = new MessageFormatter().AppendPropertyName(Rule.PropertyName);
            string message = formatter.BuildMessage(Validator.ErrorMessageSource.GetString(null));

            var rule = new ModelClientValidationRule
            {
                ValidationType = "remote",
                ErrorMessage = "رقم التسلسل موجود مسبقا"
            };
            rule.ValidationParameters.Add("url", Utils.API_PATH + "/api/Validation/IsNumUnique");
            //rule.ValidationParameters.Add("additionalfields", "*.Id");
            yield return rule;
        }
    }
}