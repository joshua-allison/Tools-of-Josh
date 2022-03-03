using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Program : Tool
    {
        public int ProgramId { get; set; }

        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string PrimaryDevelopmentPlatform { get; set; }
    }
}
