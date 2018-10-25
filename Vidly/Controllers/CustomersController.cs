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

        private readonly ICustomerService _context;
        public CustomersController(ICustomerService service)
        {
            _context = service;// = new ApplicationDbContext();
        }


        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.GetCustomer(id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _context.GetCustomer(id);
            if (customer == null)
                return HttpNotFound();
            var viewmodel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.GetMembershipTypes()
            };

            return View("Edit", viewmodel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var membershipTypes = _context.GetMembershipTypes();
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
            viewModel.MembershipTypes = _context.GetMembershipTypes();

            if (ModelState.IsValid)
            {
                try
                {


                if (viewModel.Customer.Id == 0)
                {
                        _context.AddCustomer(viewModel.Customer);
                }
                else
                {
                        //var custdb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);

                        //Vidly.Helpers.Mapper.Map(viewModel.Customer, custdb);

                        //TryUpdateModel(custdb, "", new string[] { "Name", "MembershipTypeId", "IsSubscribedToNewsletter", "BirthDate" } );

                        _context.UpdateCustomer(viewModel.Customer);

                    //custdb.Name = viewModel.Customer.Name;
                    //custdb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                    //custdb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                    //custdb.BirthDate = viewModel.Customer.BirthDate;

                }

                //_context.SaveChanges();

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
            //Customer customer = _context.DeleteCustomer
            //if (customer == null)
            //    return HttpNotFound();

            //_context.Customers.Remove(customer);
            //_context.SaveChanges();
            _context.DeleteCustomer(id);

            return RedirectToAction("Index", "Customers");
        }

    }
}