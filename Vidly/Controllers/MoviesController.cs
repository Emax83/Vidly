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
    public class MoviesController : Controller
    {

        private ApplicationDbContext dbContext;

        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: /Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            var movies = dbContext.Movies.Include(c=> c.Genre).ToList();

            //return Content(string.Format("PageIngex={0}&SortBy={1}",pageIndex,sortBy));
            return View(movies);
        }


        public ActionResult Details(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //GET: /movies/random
        public ActionResult Random()
        {
            var movie = new Movie() {
                Name="Shrek!"
                ,Id=1
            };

            var customers = new List<Customer> {
                new Customer{Name=""}
                , new Customer{Name=""}
                , new Customer{Name=""}
            };

            ViewData["Movie"] = movie;
            ViewBag.Movie = movie;

            var vieeresult = new ViewResult();
            vieeresult.ViewData.Model = movie;


            var viewmodel = new RandomMoviewViewModel
            {
                Movie=movie
                , Customers = customers
            };

            return View(viewmodel);
            //return new EmptyResult();
        }

        public ActionResult Edit(int id)
        {
            return Content("ID=" + id);
        }

        //spostato da RoutConfig.cs
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("Movies of {1}/{0}", year, month));
        }

    }
}