﻿using System;
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
    //[Authorize(Roles = "admin")]
    [AllowAnonymous]
    public class CustomersController : BaseController
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

        [HttpGet]
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
                            _context.UpdateCustomer(viewModel.Customer);
                    }

                    AddMessage("Customer saved Successfull");
                   
                    return RedirectToAction("Edit", new { id = viewModel.Customer.Id});

                }
                catch (Exception ex)
                {
                    AddError("Error saving: " + ex.Message);
                    
                }

            }
            return View("Edit", viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _context.DeleteCustomer(id);

                AddMessage("Customer deleted successfully");

            }
            catch(Exception ex)
            {
                AddError("Error during delete: " + ex.Message);
            }

            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool ActionResultUploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = System.IO.Path.GetFileName(file.FileName);
                    string _path = System.IO.Path.Combine(Server.MapPath("~/TempFiles"), HttpContext.CurrentUser().UserId.ToString(), _FileName);
                    file.SaveAs(_path);
                }
                AddMessage("File Uploaded Successfully!");
                return true;
            }
            catch (Exception ex)
            {
                AddError("File upload failed: " + ex.Message);
                return false;
            }
        }

    }
}