using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class ErrorsController : BaseController
    {
        // GET: Errors
        public ActionResult NotFound(string aspxerrorpath)
        {
            ViewBag.aspxerrorpath = aspxerrorpath;
            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }

    }
}