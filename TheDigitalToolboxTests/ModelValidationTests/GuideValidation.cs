using TheDigitalToolbox.Models;
using Xunit;


namespace TheDigitalToolboxTests.ModelValidationTests
{
    public class GuideValidation
    {
        //quick set-up function
        public Guide CreateTestObject()
        {
            Guide testObject = new Guide
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm", //test URL
                Topic = "Underwater Basket Weaving" // example guide topic
            };
            return testObject;
        }

        [Fact]
        public void TopicTooLong()
        {
            //arrange
            Guide testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Topic = TestHelpers.CreateStringOverMax(testObject.TopicSL);

            //assert (title required)
            TestHelpers.TestModelValidation(testObject, "Topic", "String length");
        }

        [Fact]
        public void TopicTooShort()
        {
            //arrange
            Guide testObject = CreateTestObject();

            //add characters to the member variable until max is reached.
            testObject.Topic = TestHelpers.CreateStringUnderMin(testObject.TopicSL);

            //assert (title required)
            if (testObject.Topic == "")
                TestHelpers.TestModelValidation(testObject, "Topic", "required");
            else
                TestHelpers.TestModelValidation(testObject, "Topic", "String length");
        }
    }
}
