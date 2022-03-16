using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "data-nav-dd-txt")]
    public class ANavDropdownTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.BuildTag("a", "dropdown-item text-secondary h3 mb-0 p-0 pl-3");
        }
    }
}