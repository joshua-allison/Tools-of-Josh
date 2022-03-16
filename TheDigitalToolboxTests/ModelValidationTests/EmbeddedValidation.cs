using TheDigitalToolbox.Models;
using Xunit;


namespace TheDigitalToolboxTests.ModelValidationTests
{
    public class EmbeddedValidation
    {
        #region TestSetup
        //quick set-up function
        public Embed CreateEmbedded()
        {
            Embed testEmbedded = new Embed
            {
                Title = "Test: This is an appropriate title.",
                Description = "Test: This is an appropriate description. It must have sufficient length.",
                ShareURL = "https://www.ledr.com/colours/green.htm", //test URL
                iFrameString = "<iframe src=\"https://www.desmos.com/calculator/qa9g2b8e3a?embed\" width=\"500\" height=\"500\" style=\"border: 1px solid #ccc\" frameborder=0></iframe>" // example embedded calculator iframe
            };
            return testEmbedded;
        }
        #endregion


        [Fact]
        public void EmbedStringMissing()
        {
            //arrange
            Embed testEmbedded = CreateEmbedded();

            //Missing end tag
            //act (change URL to improper format)
            testEmbedded.iFrameString = "";

            //assert (title required)
            TestHelpers.TestModelValidation(testEmbedded, "EmbedString", "required");
        }

        [Fact]
        public void EmbedStringMissingStartTag()
        {
            //arrange
            Embed testEmbedded = CreateEmbedded();

            //Missing start tag
            //act (change URL to improper format)
            testEmbedded.iFrameString = " src=\"https://www.desmos.com/calculator/qa9g2b8e3a?embed\" width=\"500\" height=\"500\" style=\"border: 1px solid #ccc\" frameborder=0></iframe>";

            //assert (title required)
            TestHelpers.TestModelValidation(testEmbedded, "EmbedString", "Embed string must start with \"<iframe\" and end with \"<\\iframe>\".");
        }

        [Fact]
        public void EmbedStringMissingEndTag()
        {
            //arrange
            Embed testEmbedded = CreateEmbedded();

            //Missing end tag
            //act (change URL to improper format)
            testEmbedded.iFrameString = "<iframe src=\"https://www.desmos.com/calculator/qa9g2b8e3a?embed\" width=\"500\" height=\"500\" style=\"border: 1px solid #ccc\" frameborder=0>";

            //assert (title required)
            TestHelpers.TestModelValidation(testEmbedded, "EmbedString", "Embed string must start with \"<iframe\" and end with \"<\\iframe>\".");
        }
    }
}
