using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("span", Attributes = "data-nav-brand-span")]
    public class BrandSpanNavTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.BuildTag("span", "h3 mb-3 text-nowrap");
            output.Attributes.SetAttribute("style", "text-shadow: 0px 0px 15px cyan; color: white");
        }
    }
}