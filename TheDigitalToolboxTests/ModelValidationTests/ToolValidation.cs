using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TheDigitalToolbox.Models;
using Xunit;
using static TheDigitalToolboxTests.TestHelpers;

namespace TheDigitalToolboxTests.ModelValidationTests
{
    public class ToolValidation
    {
        //quick set-up function
        public Tool CreateTestObject()
        {
            Tool testTool = new Tool
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm" //test URL
            };
            return testTool;
        }

        [Fact]
        public void TitleTooLong()
        {
            //arrange
            Tool testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Title = TestHelpers.CreateStringOverMax(testObject.TitleSL);

            //assert (title required)
            TestHelpers.TestModelValidation(testObject, "Title", "String length");
        }

        [Fact]
        public void TitleTooShort()
        {
            //arrange
            Tool testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Title = TestHelpers.CreateStringUnderMin(testObject.TitleSL);

            //assert (title required)
            if (testObject.Title == "")
                TestHelpers.TestModelValidation(testObject, "Title", "required");
            else
                TestHelpers.TestModelValidation(testObject, "Title", "String length");
        }

        [Fact]
        public void DescriptionTooLong()
        {
            //arrange
            Tool testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Description = TestHelpers.CreateStringOverMax(testObject.DescriptionSL);

            //assert (title required)
            TestHelpers.TestModelValidation(testObject, "Description", "String length");
        }

        [Fact]
        public void TextTooShort()
        {
            //arrange
            Tool testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Description = TestHelpers.CreateStringUnderMin(testObject.DescriptionSL);

            //assert (title required)
            if (testObject.Description == "")
                TestHelpers.TestModelValidation(testObject, "Description", "required");
            else
                TestHelpers.TestModelValidation(testObject, "Description", "String length");
        }

        [Fact]
        public void URLWrongFormat()
        {
            //arrange
            Tool testTool = CreateTestObject();

            //act (URL is not a web address)
            testTool.ShareURL = "This is not the format of a URL";

            //assert 
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("ShareURL") && v.ErrorMessage.Contains("Share URL must be a web address"));
        }

    }
}
