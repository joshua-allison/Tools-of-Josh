using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "data-nav-dd-btn")]
    public class NavDropdownButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string cssClasses = "btn btn-outline-secondary dropdown-toggle text-light";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.BuildTag("button", cssClasses);
            output.Attributes.AppendCssClass(cssClasses);
            output.Attributes.SetAttribute("type", "button");
            output.Attributes.SetAttribute("id", "dropdownMenuButton");
            output.Attributes.SetAttribute("data-toggle", "dropdown");
            output.Attributes.SetAttribute("aria-haspopup", "true");
            output.Attributes.SetAttribute("aria-expanded", "false");
        }
    }
}