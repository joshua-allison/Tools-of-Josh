using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("table", Attributes = "data-nav-dd-menu")]
    public class MenuNavDropdownTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.BuildTag("table", "dropdown-menu bg-dark text-light");
            output.Attributes.SetAttribute("aria-labelledby", "dropdownMenu");
            output.Attributes.SetAttribute("style", "border-color: #6c757d"); 
        }
    }
}