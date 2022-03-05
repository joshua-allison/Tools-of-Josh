using System;
using System.Collections.Generic;
using System.Text;
using TheDigitalToolbox.Models;
using Xunit;

namespace TheDigitalToolboxTests.ModelValidationTests
{
    public class ProgramValidation
    {
        //quick set-up function
        public Program CreateTestObject()
        {
            Program testObject = new Program
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm", //test URL
                Language = "Example Language: ASP.NET CORE MVC" // example Program Language
            };
            return testObject;
        }

        [Fact]
        public void LanguageTooLong()
        {
            //arrange
            Program testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Language = TestHelpers.CreateStringOverMax(testObject.LanguageSL);

            //assert (title required)
            TestHelpers.TestModelValidation(testObject, "Language", "String length");
        }

        [Fact]
        public void LanguageTooShort()
        {
            //arrange
            Program testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Language = TestHelpers.CreateStringUnderMin(testObject.LanguageSL);

            //assert (title required)
            if (testObject.Language == "")
                TestHelpers.TestModelValidation(testObject, "Language", "required");
            else
                TestHelpers.TestModelValidation(testObject, "Language", "String length");
        }
    }
}
