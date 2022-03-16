using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "data-btn-back")]
    public class BackButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SetRawPreContentElement("<i class=\"fa fa-circle-arrow-left fa-xl\"></i>");
            output.PreContent.Append("\tBack ");
            output.BuildTag("a", "btn btn-outline-primary h3 m-0 mr-2");
            output.Attributes.SetAttribute("style", "border-color: rgba(0,0,0,0)");
        }
    }
}