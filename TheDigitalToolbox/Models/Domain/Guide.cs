using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Guide : Tool
    {
        // Guides are either articles or videos made to share understanding of a topic, or to assist others in making something.
        public int GuideId { get; set; }

        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Topic { get; set; }
    }
}
