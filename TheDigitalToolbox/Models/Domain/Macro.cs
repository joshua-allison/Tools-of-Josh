using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Macro : Tool
    {
        public int MacroId { get; set; }

        //Creating code-accessible limits for the string length of the member variable
        private const int AppMinLength = 1;
        private const int AppMaxLength = 60;
        public StringLength AppSL = new StringLength(AppMinLength, AppMaxLength);
        //Creating the member variable itself
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(AppMaxLength, MinimumLength = AppMinLength, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string App { get; set; }
    }
}
