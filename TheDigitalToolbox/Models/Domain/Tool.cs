using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Tool
    {
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(1000, MinimumLength = 15, ErrorMessage = "String length for the {0} must be between {2} and {1}.")]
        public string Description { get; set; }
        [Url(ErrorMessage = "Share URL must be a web address")]
        [Required(ErrorMessage = "Please enter a 'Share' URL.")]
        public string ShareURL { get; set; }
    }
}
