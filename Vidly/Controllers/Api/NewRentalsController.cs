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
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public NewRentalsController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalViewModel newRental)
        {
            if (newRental.MoviesIds.Count == 0)
                return BadRequest("No movie to rent");

            var customer = _dbContext.Customers.Single(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Invalid customer id");

            var movies = _dbContext.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList();

            if (movies.Count!=newRental.MoviesIds.Count)
                return BadRequest("One or more movies invalid"); 

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.UtcNow
                };

                _dbContext.Rentals.Add(rental);
            }

            _dbContext.SaveChanges();

            return Ok("");

        }

        [HttpPost]
        public IHttpActionResult EndRental(int rentalId)
        {
            var rental = _dbContext.Rentals.Single(r => r.Id == rentalId);
            rental.DateReturned = DateTime.UtcNow;

            var movie = _dbContext.Movies.Single(m => m.Id == rental.Movie.Id);
            movie.NumberAvailable++;

            _dbContext.SaveChanges();

            return Ok("");
        }

    }
}
