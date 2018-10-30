using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    [HandleError]
    public class BaseController : Controller
    {
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

    }
}