using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Infrastracture;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService service)
        {
            _customerService = service;
        }

        //GET /API/customers/GetCustomers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerService.GetCustomers();
        }

        //GET /API/customers/GetCustomer
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //POST /API/customers/CreateCustomer
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _customerService.AddCustomer(customer);

            return customer;
        }

        //PUT /API/customers/Update
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (!_customerService.UpdateCustomer(customer))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        //DELETE /API/customers/Delete/1
        public void DeleteCustomer(int id)
        {
            if (!_customerService.DeleteCustomer(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

    }
}
