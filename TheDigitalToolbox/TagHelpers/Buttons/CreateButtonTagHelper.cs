using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "data-btn-create")]
    public class CreateButtonATagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SetRawPreContentElement("<i class=\"fa fa-circle-plus fa-xl\"></i>");
            output.BuildTag("a", "btn btn-outline-success h3 m-0 mr-2");
            output.Attributes.SetAttribute("style", "border-color: rgba(0,0,0,0)");
        }
    }
    [HtmlTargetElement("button", Attributes = "data-btn-create")]
    public class CreateButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SetRawPreContentElement("<i class=\"fa fa-circle-plus fa-xl\"></i>");
            output.BuildTag("button", "btn btn-outline-success h3 m-0 mr-2");
            output.Attributes.SetAttribute("style", "border-color: rgba(0,0,0,0)");
        }
    }
}