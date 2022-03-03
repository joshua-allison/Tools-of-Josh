using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Macro : Tool
    {
        public int MacroId { get; set; }

        // Which application was the macro developed for?
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string TargetApplication { get; set; }
    }
}
