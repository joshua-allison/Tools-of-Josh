using TheDigitalToolbox.Models;
using Xunit;


namespace TheDigitalToolboxTests
{
    public class GuideValidation
    {
        #region TestSetup
        //quick set-up function
        public Guide CreateGuide()
        {
            Guide testEmbedded = new Guide
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm", //test URL
                Topic = "Underwater Basket Weaving" // example guide topic
            };
            return testEmbedded;
        }
        #endregion


        //TODO finish unit tests for Guide Validation
        [Fact]
        public void TopicMissing()
        {
            //arrange
            Guide testEmbedded = CreateGuide();

            //Missing end tag
            //act (change URL to improper format)
            testEmbedded.EmbedString = "";

            //assert (title required)
            TestHelpers.TestModelValidation(testEmbedded, "EmbedString", "required");
        }
    }
}
