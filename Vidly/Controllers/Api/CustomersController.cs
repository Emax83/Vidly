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
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customers = _customerService.GetCustomers();

            if (!string.IsNullOrWhiteSpace(query))
                customers = customers.Where(c => c.Name.Contains(query));

            return Ok(customers);
        }

        //GET /API/customers/GetCustomer
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(customer);
        }

        //POST /API/customers/CreateCustomer
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _customerService.AddCustomer(customer);

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        //PUT /API/customers/Update
        [HttpPut]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (!_customerService.UpdateCustomer(customer))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(customer);
        }

        //DELETE /API/customers/Delete/1
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!_customerService.DeleteCustomer(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok();
        }

    }
}
