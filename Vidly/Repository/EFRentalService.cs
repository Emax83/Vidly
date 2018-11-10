using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Infrastracture;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Repository
{
    
    public class EFRentalService : IRentalService
    {
        private readonly ApplicationDbContext _dbContext;
        public EFRentalService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Rental> GetRentals()
        {
            throw new NotImplementedException();
        }

        public Rental GetRental(int id)
        {
            throw new NotImplementedException();
        }

    
        public bool AddNewRental(NewRentalViewModel newRental)
        {
            var customer = _dbContext.Customers.Single(c => c.Id == newRental.CustomerId);

            if (customer == null)
                throw  new Exception("Invalid customer id");

            var movies = _dbContext.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                throw new Exception("One or more movies invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    throw new Exception("Movie not available");

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

            return true;
        }

        public bool EndRental(int id)
        {
            var rental = _dbContext.Rentals.Single(r => r.Id == id);
            if (rental == null)
                throw new Exception("Rental Not Available");

            rental.DateReturned = DateTime.UtcNow;

            var movie = _dbContext.Movies.Single(m => m.Id == rental.Movie.Id);
            if (movie == null)
                throw new Exception("Rental Not Available");

            movie.NumberAvailable++;

            _dbContext.SaveChanges();

            return true;
        }

      
    }
}