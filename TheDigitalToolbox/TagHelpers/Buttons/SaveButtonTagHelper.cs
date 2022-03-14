using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TheDigitalToolbox.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "data-btn-save")]
    public class SaveButtonTagHelper : TagHelper
    {
        //  Note:   This tag hlper will only work on "button" tags
        //              It will also only work in forms, and this button acts as form submission.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //  This looks janky. There's probably a better way of doing it
            //  Mixing buttons with form-group input is somewhat tricky, and this is how I got it to work
            output.SetRawPreContentElement(
                "<table class=\"form-group mb-2\">\n" +
                    "\t<tr>\n" +
                        "\t\t<td>\n" +
                            "\t\t\t<i class=\"fa fa-floppy-disk fa-xl text-light\"></i>\n"
            );
            output.Content.Clear();
            output.Content.Append("\tSave");
            output.BuildTag("button", "text-light btn btn-outline-primary");
            output.Attributes.SetAttribute("type", "submit");
            output.SetRawPostContentElement(
                        "\t\t</td>\n" +
                    "\t</tr>" +
                "</table>" 
            );
        }
    }
}