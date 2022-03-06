using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class Embedded : Tool
    {
        public int EmbeddedId { get; set; }

        [Required(ErrorMessage = "A(n) {0} is required.")]
        [RegularExpression(@"^<iframe.*</iframe>$", ErrorMessage = "Embed string must start with \"<iframe\" and end with \"<\\iframe>\". ")]
        public string EmbedString { get; set; }
    }
}
