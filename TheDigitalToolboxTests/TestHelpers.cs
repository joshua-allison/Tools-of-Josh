using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xunit;

namespace TheDigitalToolboxTests
{
    static class TestHelpers
    {
        #region Model Validation Test Helpers
        public static IList<ValidationResult> ValidateModel(object model)
        // function found @ https://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        public static void TestModelValidation<T>(T testModelObject, string MemberName, string ErrorMessage)
        {
            //This test assumes there will be a model validation error, rather than model validation success

            //Pass in the arranged test domain model with an intentional misformating in one of it's properties (MemberName). If there is a formatting error, it should produce a custom Error Message
            Assert.Contains(ValidateModel(testModelObject), v => v.MemberNames.Contains(MemberName) && v.ErrorMessage.Contains(ErrorMessage));
            return;
        }
        #endregion Model Validation Test Helpers

    }
}
