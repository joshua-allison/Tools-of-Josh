using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("tr", Attributes = "data-nav-dd-row")]
    public class RowNavDropdownTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.BuildTag("tr", "dropdown-item text-secondary");
        }
    }
}