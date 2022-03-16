using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Guide : Tool
    {
        // Guides are either articles or videos made to share understanding of a topic, or to assist others in making something.
        //Creating code-accessible limits for the string length of the member variable
        private const int TopicMinLength = 1;
        private const int TopicMaxLength = 60;
        public StringLength TopicSL = new StringLength(TopicMinLength, TopicMaxLength);
        //Creating the member variable itself
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(TopicMaxLength, MinimumLength = TopicMinLength, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Topic { get; set; }
    }
}
