using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "data-btn-delete")]
    public class DeleteButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.Clear();
            output.SetRawPreContentElement("<i class=\"fa fa-trash-can fa-xl\"></i>");
            output.Content.Append("\tDelete");
            output.BuildTag("a", "btn btn-outline-danger h3 m-0 mr-2");
            output.Attributes.SetAttribute("style", "border-color: rgba(0,0,0,0)");
        }
    }
}