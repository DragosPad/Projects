using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRestaurant.ViewModel
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, string height, object htmlAttributes)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            // builder.MergeAttribute("class", imagClass);
            builder.MergeAttribute("height", height);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}