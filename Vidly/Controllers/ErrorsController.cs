using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult NotFound(string aspxerrorpath)
        {
            return View(aspxerrorpath);
        }

        public ActionResult Unauthorized()
        {
            return View();
        }

    }
}