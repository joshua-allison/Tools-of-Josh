using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class HelpfulLink : Tool
    {
        // Helpful links are descriptive links to exterior websites.
        public int HelpfulLinkId { get; set; }

        //Creating code-accessible limits for the string length of the member variable
        private const int SubjectMinLength = 1;
        private const int SubjectMaxLength = 20;
        public StringLength SubjectSL = new StringLength(SubjectMinLength, SubjectMaxLength);
        //Creating the member variable itself
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(SubjectMaxLength, MinimumLength = SubjectMinLength, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Subject { get; set; }
    }
}
