using TheDigitalToolbox.Models;
using Xunit;


namespace TheDigitalToolboxTests.ModelValidationTests
{
    public class HelpfulLinkValidation
    {
        //quick set-up function
        public HelpfulLink CreateTestObject()
        {
            HelpfulLink testObject = new HelpfulLink
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm", //test URL
                Subject = "Test Subject"
            };
            return testObject;
        }

        [Fact]
        public void SubjectTooLong()
        {
            //arrange
            HelpfulLink testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Subject = TestHelpers.CreateStringOverMax(testObject.SubjectSL);

            //assert (title required)
            TestHelpers.TestModelValidation(testObject, "Subject", "String length");
        }

        [Fact]
        public void SubjectTooShort()
        {
            //arrange
            HelpfulLink testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Subject = TestHelpers.CreateStringUnderMin(testObject.SubjectSL);

            //assert (title required)
            if (testObject.Subject == "")
                TestHelpers.TestModelValidation(testObject, "Subject", "required");
            else
                TestHelpers.TestModelValidation(testObject, "Subject", "String length");
        }
    }
}
