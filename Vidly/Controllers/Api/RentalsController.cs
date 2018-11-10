using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Infrastracture;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly IRentalService _service;
        public RentalsController(IRentalService service)
        {
            _service = service;
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalViewModel newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie to rent");

            try
            {
                _service.AddNewRental(newRental);

                return Ok("");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IHttpActionResult EndRental(int rentalId)
        {
            try
            {
                _service.EndRental(rentalId);

                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
