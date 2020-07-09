using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Infrastracture;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class RentalsController : BaseController
    {

        private readonly IRentalService _service;
        public RentalsController(IRentalService service)
        {
            _service = service;
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