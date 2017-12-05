
using System.Web.Mvc;

namespace NorthwindApp
{
    public static class HtmlHelpersExtensions
    {
        public static MvcHtmlString Button(this HtmlHelper html, string label = "Create")
        {
            var buttonHtml = $@"
                <input type='submit' value='{label}' class='btn btn-default' />
                    ";

            return new MvcHtmlString(buttonHtml);
        }

        public enum HtmlHTypes
        {
        H1 =1 ,
        H2,
        H3,
        H4,
        H5,
        H6
        }

        public static MvcHtmlString H1(this HtmlHelper html, string content)
        {
            return HtmlH(HtmlHTypes.H1, content);
        }


        private static MvcHtmlString HtmlH(HtmlHTypes type, string content)
        {
            var htmlType = (int)type;

            var buttonHtml = $@"
                <h{htmlType}>{content}</h{htmlType}>
                    ";

            return new MvcHtmlString(buttonHtml);
        }

        public static MvcHtmlString H2(this HtmlHelper html, string content)
        {
            return HtmlH(HtmlHTypes.H2, content);
        }
        public static MvcHtmlString H3(this HtmlHelper html, string content)
        {
            return HtmlH(HtmlHTypes.H3, content);
        }
        public static MvcHtmlString H4(this HtmlHelper html, string content)
        {
            return HtmlH(HtmlHTypes.H4, content);
        }
        public static MvcHtmlString H5(this HtmlHelper html, string content)
        {
            return HtmlH(HtmlHTypes.H5, content);
        }
        public static MvcHtmlString H6(this HtmlHelper html, string content)
        {
            return HtmlH(HtmlHTypes.H6, content);
        }
    }
}