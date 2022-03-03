using System;
using Xunit;
using TheDigitalToolbox.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace TheDigitalToolboxTests
{
    public class ToolTests
    {
        #region TestSetup
        //quick set-up function
        public Tool CreateTestTool()
        {
            Tool testTool = new Tool
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm" //test URL
            };
            return testTool;
        }

        private IList<ValidationResult> ValidateModel(object model)
        // function found @ https://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
        #endregion 

        #region TitleTests
        [Fact]
        public void TitleTooShort()
        {
            //arrange
            Tool testTool = CreateTestTool();

            //act (Title with length 1)
            testTool.Title = "T";

            //assert (Shorter than the minimum)
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("Title") && v.ErrorMessage.Contains("String length"));
        }

        [Fact]
        public void TitleTooLong()
        {
            //arrange
            Tool testTool = CreateTestTool();

            //act (Title with length 64)
            testTool.Title = "0123456789-0123456789-0123456789-0123456789-0123456789-0123456789";

            //assert (Greater than the maximum)
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("Title") && v.ErrorMessage.Contains("String length"));
        }

        [Fact]
        public void TitleMissing()
        {
            //arrange & act (omit title)
            Tool testTool = new Tool
            {
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm" //test URL
            };

            //assert (title required)
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("Title") && v.ErrorMessage.Contains("Please enter a title"));
        }
        #endregion 

        #region DescriptionTests
        [Fact]
        public void DescriptionTooShort()
        {
            //arrange
            Tool testTool = CreateTestTool();

            //act (Description with length 1)
            testTool.Description = "T";

            //assert (Shorter than the minimum)
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("Description") && v.ErrorMessage.Contains("String length"));
        }

        [Fact]
        public void DescriptionTooLong()
        {
            //arrange
            Tool testTool = CreateTestTool();

            //act (Description with length 1001)
            testTool.Description = "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

            //assert (Greater than the maximum)
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("Description") && v.ErrorMessage.Contains("String length"));
        }

        [Fact]
        public void DescriptionMissing()
        {
            //arrange & act (omit description)
            Tool testTool = new Tool
            {
                Title = "Test: This is an appropriate title.",
                ShareURL = "https://www.ledr.com/colours/green.htm" //test URL
            };

            //assert (title required)
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("Description") && v.ErrorMessage.Contains("Please enter a description"));
        }

        #endregion 

        #region URLTests
        [Fact]
        public void URLMissing()
        {
            //arrange & act (omit URL)
            Tool testTool = new Tool
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length."
            };

            //assert (URL required)
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("ShareURL") && v.ErrorMessage.Contains("Please enter a 'Share' URL."));
        }

        [Fact]
        public void URLWrongFormat()
        {
            //arrange
            Tool testTool = CreateTestTool();

            //act (URL is not a web address)
            testTool.ShareURL = "This is not the format of a URL";

            //assert 
            Assert.Contains(ValidateModel(testTool), v => v.MemberNames.Contains("ShareURL") && v.ErrorMessage.Contains("Share URL must be a web address"));
        }
        #endregion URLTests

    }
}
