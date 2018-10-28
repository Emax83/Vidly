﻿using System;
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
        public IEnumerable<Movie> GetMovies()
        {
            return _movieService.GetMovies();
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
        public void UpdateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (!_movieService.UpdateMovie(movie))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        //DELETE /API/customers/Delete/1
        public void DeleteMovie(int id)
        {
            if (!_movieService.DeleteMovie(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

    }
}