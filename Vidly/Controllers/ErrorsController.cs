using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound(string aspxerrorpath)
        {
            ViewBag.ErrorUrl = aspxerrorpath;
            return View();
        }
    }
}