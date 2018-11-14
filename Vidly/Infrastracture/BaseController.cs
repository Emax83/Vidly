using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Vidly.Infrastracture;

namespace Vidly
{
    [HandleError]
    public class BaseController : Controller
    {
        protected virtual UserPrincipal UserPrincipal
        {
            get { return HttpContext.User as UserPrincipal; }
        }

        public void AddMessage(string message)
        {
            TempData["Message"] = message;
        }

        public void AddError(string message)
        {
            TempData["Error"] = message;
        }

        public void AddWarning(string message)
        {
            TempData["Warning"] = message;
        }

        //protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        //{
        //    string[] cultures = { "es-CL", "es-GT", "en-US" };
        //    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("it-IT");
        //    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

        //    return base.BeginExecuteCore(callback, state);
        //}

    }
}