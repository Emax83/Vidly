using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genres
        public ActionResult Index()
        {
            return View();
        }
    }
}