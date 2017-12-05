using System.Web.Mvc;

namespace aspnet.HtmlHelper
{
    public static class HtmlHelpersExtensions
    {

		public enum HeadersType
        {
			H1 = 1,
			H2,
			H3,
			H4,
			H5,
			H6
        }


        public static MvcHtmlString Headers(HeadersType type ,string title)
        {
            var size = (int)type;
            var h = $@"h{size}>{title}</h{size}>";
            return new MvcHtmlString(h);
        }

        public static MvcHtmlString H1(this HtmlHelper html, string content)
        {
            return Headers(HeadersType.H1, content);
        }
    }
}