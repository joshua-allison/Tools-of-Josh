using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TheDigitalToolbox.Models;
using Xunit;

namespace TheDigitalToolboxTests
{
    class TestHelpers
    {
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

        public static string CreateStringOverMax(StringLength testObjectSL)
        {
            // Accept a StringLength object and create a string of characters with a length over the maximum provided. 
            string result = "";
            int overMax = testObjectSL.GetMax() + 1;
            for (int i = 0; i < overMax; i++)
            {
                // (it doesn't matter what character we use, what we care about is how many there are.
                result = result + "x";
            }
            return result;
        }

        public static string CreateStringUnderMin(StringLength testObjectSL)
        {
            // Accept a StringLength object and create a string of characters with a length under the minimum provided. 
            string result = "";
            int underMin = testObjectSL.GetMin() - 1;
            if (underMin == 0) return "";
            for (int i = 0; i < underMin; i++)
            {
                // (it doesn't matter what character we use, what we care about is how many there are.
                result = result + "x";
            }
            return result;
        }
    }
}
