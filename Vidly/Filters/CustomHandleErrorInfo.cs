using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class CustomHandleErrorInfo : HandleErrorInfo
    {
        public string AreaName { get; }
        public bool IsLocal { get; }
        public CustomHandleErrorInfo(Exception exception, string controllerName, string actionName)
            :base(exception,controllerName,actionName)
        {
            AreaName = "";
            IsLocal = HttpContext.Current.Request.Url.Host.Contains("localhost");
        }
    }
}