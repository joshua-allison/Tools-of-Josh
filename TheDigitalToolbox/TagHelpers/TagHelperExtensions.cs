using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

// "Murach's ASP.NET Core MVC" by Mary Delamater and Joel Murach
// Chapter 15 - How to work with tag helpers, partial views, and view components
// Page 613 - How to use extension methods with tag helpers
public static class TagHelperExtensions
{
    public static void AppendCssClass(this TagHelperAttributeList list, string newCssClasses)
    {
        string oldCssClasses = list["class"]?.Value?.ToString();
        string cssClasses = (string.IsNullOrEmpty(oldCssClasses)) ?
        newCssClasses : $"{oldCssClasses} {newCssClasses}";
        list.SetAttribute("class", cssClasses);
    }
    public static void BuildTag(this TagHelperOutput output, string tagName, string classNames)
    {
        output.TagName = tagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.AppendCssClass(classNames);
    }
    public static void BuildLink(this TagHelperOutput output, string url, string className)
    {
        output.BuildTag("a", className);
        output.Attributes.SetAttribute("href", url);
    }
    public static void SetRawPreContentElement(this TagHelperOutput output, string rawHTML)
    // By Josh Allison (adapted from the above extension methods, and https://www.c-sharpcorner.com/article/creating-custom-tag-helpers-with-asp-net-core-mvc/)
    {
        var sb = new StringBuilder();
        sb.AppendFormat(rawHTML);
        output.PreContent.SetHtmlContent(sb.ToString());
    }
    public static void SetRawPostContentElement(this TagHelperOutput output, string rawHTML)
    // By Josh Allison (adapted from the above extension methods, and https://www.c-sharpcorner.com/article/creating-custom-tag-helpers-with-asp-net-core-mvc/)
    {
        var sb = new StringBuilder();
        sb.AppendFormat(rawHTML);
        output.PostContent.SetHtmlContent(sb.ToString());
    }
}