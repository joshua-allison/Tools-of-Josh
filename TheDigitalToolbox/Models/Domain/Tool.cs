using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Tool
    {
        // There will be many tools in the toolbox of varying uses, structure, and source of synthesis, but all tools will need the following:

        // Which user uploaded the tool, automatically set by the site (no need for validation)
        public User Uploader { get; set; }

        //The people(s) or organization credited for the creation of the tool, specifically in reference to its top-level functionality
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Creator { get; set; }

        // A Title (or name)
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Title { get; set; }

        // A Description highlighting what it does and how to use it
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [StringLength(1000, MinimumLength = 15, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Description { get; set; }

        // A URL where the tool itself can be found, or the sourcecode used to build the tool
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [Url(ErrorMessage = "Share URL must be a web address")]
        public string ShareURL { get; set; }
    }
}
