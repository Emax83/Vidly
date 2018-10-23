using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Infrastracture;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Helpers;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
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

            var movies = _dbContext.Movies.Include(c=> c.Genre).ToList();

            //return Content(string.Format("PageIngex={0}&SortBy={1}",pageIndex,sortBy));
            return View(movies);
        }


        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include("Genre").SingleOrDefault(c => c.Id == id);
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

        // Movies/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewModels.MovieViewModel viewModel = new MovieViewModel();
            viewModel.Genres = _dbContext.Genres.ToList();
            viewModel.Movie = new Movie();
            return View("Edit",viewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost([Bind(Exclude = "Id")] MovieViewModel viewModel)
        {
            viewModel.Genres = _dbContext.Genres.ToList();
            if (ModelState.IsValid)
            {
                Movie newMovie = new Movie();

                Mapper.Map(viewModel.Movie, newMovie);

                newMovie.DateAdded = DateTime.Now;

                _dbContext.Movies.Add(newMovie);

                _dbContext.SaveChanges();

                return RedirectToAction("Details",new { id= newMovie.Id});
            }
            return View(viewModel);
        }


        // Movies/Edit/1
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Movie movie = null;

            if (id.HasValue)
            {
                movie = _dbContext.Movies.SingleOrDefault(c => c.Id == id);
                if (movie == null)
                    return HttpNotFound();
            }
            else
            {
                movie = new Movie();
            }
            MovieViewModel viewModel = new MovieViewModel
            {
                Movie = movie,
                Genres = _dbContext.Genres.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id, MovieViewModel viewModel)
        {
            viewModel.Genres = _dbContext.Genres.ToList();
            if (ModelState.IsValid)
            {
                var dbMovie = _dbContext.Movies.Single(c => c.Id == id);

                Mapper.Map(viewModel.Movie, dbMovie);

                TryUpdateModel(dbMovie, "", new string[] { "Name", "GenreId", "NumberInStock", "Price" ,"ReleaseDate"});

                _dbContext.SaveChanges();

                TempData["Message"] = "Saved successfull";

                return RedirectToAction("Details", new { id = id });
            }
            TempData["Warning"] = "Something going wrong";
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Save(int? id)
        {
            return RedirectToAction("Edit", new { id = id });
        }

        [HttpPost]
        [ActionName("Save")]
        [ValidateAntiForgeryToken]
        public ActionResult SavePost(MovieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Movie.Id == 0)
                {
                    _dbContext.Movies.Add(viewModel.Movie);
                }
                else
                {
                    var moviedb = _dbContext.Movies.Single(c => c.Id == viewModel.Movie.Id);

                    Vidly.Helpers.Mapper.Map(viewModel.Movie, moviedb);

                    TryUpdateModel(moviedb, "", new string[] { "Name", "GenreId", "ReleaseDate", "DateAdded","Price", "NumberInStock" });
                }

                _dbContext.SaveChanges();

                //TempData["Message"] = "Movie saved Successfull";
                return RedirectToAction("Index", "Movies");

            }
            return View("Edit", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        //spostato da RoutConfig.cs
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("Movies of {1}/{0}", year, month));
        }

    }
}