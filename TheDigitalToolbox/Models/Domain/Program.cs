using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Program : Tool
    {
        public int ProgramId { get; set; }


        //Creating code-accessible limits for the string length of the member variable
        private const int LanguageMinLength = 1;
        private const int LanguageMaxLength = 60;
        public StringLength LanguageSL = new StringLength(LanguageMinLength, LanguageMaxLength);
        //Creating the member variable itself
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(LanguageMaxLength, MinimumLength = LanguageMinLength, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Language { get; set; }
    }
}
