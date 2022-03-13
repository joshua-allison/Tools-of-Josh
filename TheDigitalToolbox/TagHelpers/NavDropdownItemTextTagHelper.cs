using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "data-nav-dd-txt")]
    public class NavDropdownItemTextTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string cssClasses = "dropdown-item text-secondary h3 mb-0 p-0 pl-3";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.BuildTag("a", cssClasses);
            output.Attributes.AppendCssClass(cssClasses);
        }
    }
}