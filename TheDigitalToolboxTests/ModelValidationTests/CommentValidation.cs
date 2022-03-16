using System;
using System.Collections.Generic;
using System.Text;
using TheDigitalToolbox.Models;
using Xunit;

namespace TheDigitalToolboxTests.ModelValidationTests
{
    public class CommentValidation
    {
        //quick set-up function
        public Comment CreateTestObject()
        {
            Comment testObject = new Comment
            {
                Text = "This is an acceptable value for the text field."
            };
            return testObject;
        }

        [Fact]
        public void TextTooLong()
        {
            //arrange
            Comment testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Text = TestHelpers.CreateStringOverMax(testObject.TextSL);

            //assert (title required)
            TestHelpers.TestModelValidation(testObject, "Text", "String length");
        }

        [Fact]
        public void TextTooShort()
        {
            //arrange
            Comment testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Text = TestHelpers.CreateStringUnderMin(testObject.TextSL);

            //assert (title required)
            if (testObject.Text == "")
                TestHelpers.TestModelValidation(testObject, "Text", "required");
            else
                TestHelpers.TestModelValidation(testObject, "Text", "String length");
        }
    }
}
