using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class iFrameTool: Tool
    {
        public int iFrameToolId { get; set; }

        [RegularExpression(@"^<iframe.*</iframe>$", ErrorMessage = "Embed string must start with \"<iframe\" and end with \"<\\iframe>\". ")]
        public string EmbedString { get; set; }
    }
}
