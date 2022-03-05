using System;
using System.Collections.Generic;
using System.Text;
using TheDigitalToolbox.Models;
using Xunit;

namespace TheDigitalToolboxTests.ModelValidationTests
{
    public class MacroValidation
    {
        //quick set-up function
        public Macro CreateTestObject()
        {
            Macro testObject = new Macro
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm", //test URL
                App = "Example Application Name" // example Macro app
            };
            return testObject;
        }

        [Fact]
        public void AppTooLong()
        {
            //arrange
            Macro testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.App = TestHelpers.CreateStringOverMax(testObject.AppSL);

            //assert (title required)
            TestHelpers.TestModelValidation(testObject, "App", "String length");
        }

        [Fact]
        public void AppTooShort()
        {
            //arrange
            Macro testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.App = TestHelpers.CreateStringUnderMin(testObject.AppSL);

            //assert (title required)
            if (testObject.App == "")
                TestHelpers.TestModelValidation(testObject, "App", "required");
            else
                TestHelpers.TestModelValidation(testObject, "App", "String length");
        }
    }
}
