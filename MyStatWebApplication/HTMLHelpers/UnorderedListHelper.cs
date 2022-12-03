using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStatWebApplication.Models;

namespace MyStatWebApplication.HTMLHelpers;

public static class UnorderedListHelper
{
    public static HtmlString RenderHomeworks(this IHtmlHelper source, IEnumerable<Homework> homeworks)
    {
        var builder = new StringBuilder();
        
        builder.Append("<ul>");
        
        foreach (var homework in homeworks)
        {
            builder.Append("<li>");
            builder.Append("<div id=\"container\">");
            builder.Append($"<span>{homework.Id}: {homework.DateTime.ToString("d")}</span>");
            builder.Append($"<input type=\"button\" class=\"download-button\" data-id=\"{homework.Id}\" value=\"Download\"></button>");
            builder.Append($"<input type=\"button\" class=\"remove-button\" data-id=\"{homework.Id}\" value=\"🗑\"></button>");
            builder.Append("</div>");
            builder.Append("</li>");
        }
        
        builder.Append("</ul>");
        
        return new HtmlString(builder.ToString());
    }
}