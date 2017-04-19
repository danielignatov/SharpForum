namespace SharpForum.App.Extentions
{
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlHelperExtentions
    {
        // Example Razor: @Html.CustomSubmitButton("Submit")
        public static MvcHtmlString CustomSubmitButton(this System.Web.WebPages.Html.HtmlHelper helper, string buttonText)
        {
            TagBuilder builder = new TagBuilder("button");
            // Css
            builder.AddCssClass("btn btn-success");
            // Attributes
            builder.MergeAttribute("type", "submit");
            // Setting Button Text
            builder.InnerHtml = buttonText;

            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        // Example Razor: @Html.CustomImage("http://example.com/img.jpg", "Image of example")
        public static MvcHtmlString CustomImage(this HtmlHelper helper, string url, string alt)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass("img-responsive");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alt);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString CheckBoxSimple(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            string checkBoxWithHidden = htmlHelper.CheckBox(name, htmlAttributes).ToHtmlString().Trim();
            string pureCheckBox = checkBoxWithHidden.Substring(0, checkBoxWithHidden.IndexOf("<input", 1));
            return new MvcHtmlString(pureCheckBox);
        }
    }
}