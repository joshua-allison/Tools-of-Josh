using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Embed : Tool
    {
        [Required(ErrorMessage = "A(n) {0} is required.")]
        [RegularExpression(@"^<iframe.*</iframe>$", ErrorMessage = "String must start and end with iframe tags.")]
        public string iFrameString { get; set; }
    }
}
