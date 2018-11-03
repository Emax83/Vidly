using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class RentalsController : Controller
    {

        public RentalsController()
        {

        }


        // GET: Rentals
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

    }
}