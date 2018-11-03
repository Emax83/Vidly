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
    public class MoviesController : ApiController
    {

        private readonly IMovieService _movieService;
        public MoviesController(IMovieService service)
        {
            _movieService = service;
        }

        //GET /API/customers/GetCustomers
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var movies = _movieService.GetMovies();
            movies = movies.Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                movies = movies.Where(m => m.Name.Contains(query));

            return Ok(movies);
        }

        //GET /API/customers/GetCustomer
        [HttpGet]
        public Movie GetMovie(int id)
        {
            var Movie = _movieService.GetMovie(id);
            if (Movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Movie;
        }

        //POST /API/customers/CreateCustomer
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _movieService.AddMovie(movie);
            return movie;
        }

        //PUT /API/customers/Update
        [HttpPut]
        public IHttpActionResult UpdateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (!_movieService.UpdateMovie(movie))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(movie);

        }

        //DELETE /API/customers/Delete/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            if (!_movieService.DeleteMovie(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

    }
}
