using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Tool
    {
        // There will be many tools in the toolbox of varying uses, structure, and source of synthesis, but all tools will need the following:

        // A Title (or name)
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Title { get; set; }

        // A Description highlighting what it does and how to use it
        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(1000, MinimumLength = 15, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Description { get; set; }
        
        // A URL where the tool itself can be found, or the sourcecode used to build the tool
        [Url(ErrorMessage = "Share URL must be a web address")]
        [Required(ErrorMessage = "Please enter a 'Share' URL.")]
        public string ShareURL { get; set; }
    }
}
