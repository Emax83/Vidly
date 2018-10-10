using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Infrastracture;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers;
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>() {
        //        new Customer{}
        //        ,new Customer{}
        //        ,new Customer{}
        //        ,new Customer{}
        //    };
        //}

    }
}