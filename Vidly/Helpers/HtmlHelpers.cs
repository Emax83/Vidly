using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString HasPermission(this HtmlHelper html,string permission)
        {
            return new MvcHtmlString("");
        }

        public static MvcHtmlString CurrentUser(this HtmlHelper html)
        {
            
            return new MvcHtmlString("");
        }

        public static MvcHtmlString AntiforgeryTokenAjax(this HtmlHelper html)
        {

            return new MvcHtmlString("");
        }
    }
}