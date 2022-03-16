using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "data-nav-dd-btn")]
    public class ButtonNavDropdownTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.BuildTag("button", "btn btn-outline-secondary dropdown-toggle text-light");
            output.Attributes.SetAttribute("type", "button");
            output.Attributes.SetAttribute("id", "dropdownMenuButton");
            output.Attributes.SetAttribute("data-toggle", "dropdown");
            output.Attributes.SetAttribute("aria-haspopup", "true");
            output.Attributes.SetAttribute("aria-expanded", "false");
        }
    }
}