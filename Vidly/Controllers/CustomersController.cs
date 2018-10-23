using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Infrastracture;
using Vidly.Models;
using Vidly.ViewModels;

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
            var customers = _context.Customers.Include(c => c.MembershipType);
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewmodel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("Edit", viewmodel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            //return View(new Customer());
            return View("Edit",viewmodel);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerViewModel viewModel)
        {
            viewModel.MembershipTypes = _context.MembershipTypes.ToList();

            if (ModelState.IsValid)
            {
                try
                {


                if (viewModel.Customer.Id == 0)
                {
                    _context.Customers.Add(viewModel.Customer);
                }
                else
                {
                    var custdb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);

                    Vidly.Helpers.Mapper.Map(viewModel.Customer, custdb);

                    TryUpdateModel(custdb, "", new string[] { "Name", "MembershipTypeId", "IsSubscribedToNewsletter", "BirthDate" } );

                    //custdb.Name = viewModel.Customer.Name;
                    //custdb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                    //custdb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                    //custdb.BirthDate = viewModel.Customer.BirthDate;

                }

                _context.SaveChanges();

                TempData["Message"] = "Customer saved Successfull";
                return RedirectToAction("Index", "Customers");

                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Error saving: " + ex.Message;
                }

            }
            return View("Edit", viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            Customer customer = _context.Customers.Single(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

    }
}