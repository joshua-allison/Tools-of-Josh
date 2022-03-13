using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("input", Attributes = "data-nav-dd-txt")]
    public class NavDropdownItemInputTextTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.BuildTag("input", "dropdown-item text-secondary h3 mb-0 p-0 pl-3");
        }
    }
}