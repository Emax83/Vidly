using System;
using System.Web.Mvc;
using Vidly.Infrastracture;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Helpers;
using System.Web;
using System.Collections.Generic;
using System.Net;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class MoviesController : BaseController
    {

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService service)
        {
            _movieService = service;// = new ApplicationDbContext();
        }

        // GET: /Movies
        public ActionResult Index()//(int? pageIndex, string sortBy)
        {
            //if (!pageIndex.HasValue)
            //{
            //    pageIndex = 1;
            //}
            //if (string.IsNullOrWhiteSpace(sortBy))
            //{
            //    sortBy = "Name";
            //}

            var movies = _movieService.GetMovies();//.Movies.Include(c=> c.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _movieService.GetMovie(id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //GET: /movies/random
        public ActionResult Random()
        {
            //var movie = new Movie() {
            //    Name="Shrek!"
            //    ,Id=1
            //};


            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            //var vieeresult = new ViewResult();
            //vieeresult.ViewData.Model = movie;


            //var viewmodel = new RandomMoviewViewModel
            //{
            //    Movie=movie
            //    , Customers = customers
            //};

            //return View(viewmodel);
            return new EmptyResult();
        }

        // Movies/Create
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            MovieViewModel viewModel = new MovieViewModel() {
                Genres = _movieService.GetGenres(),
                Movie = new Movie()
            };

            return View("Edit",viewModel);
        }

        // Movies/Edit/1
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movie movie = _movieService.GetMovie(id);
            if (movie == null)
                return HttpNotFound();
            var viewmodel = new MovieViewModel
            {
                Movie = movie,
                Genres = _movieService.GetGenres()
            };

            return View("Edit", viewmodel);
        }


        //https://haacked.com/archive/2010/07/16/uploading-files-with-aspnetmvc.aspx/
        //https://cmatskas.com/upload-files-in-asp-net-mvc-with-javascript-and-c/
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieViewModel viewModel, IEnumerable<HttpPostedFileBase> files)
        {
            viewModel.Genres = _movieService.GetGenres();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var file in files)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = System.IO.Path.GetFileName(file.FileName);
                            var path = System.IO.Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                            file.SaveAs(path);
                        }
                    }

                    if (viewModel.Movie.Id == 0)
                    {
                        viewModel.Movie.DateAdded = DateTime.UtcNow;
                        _movieService.AddMovie(viewModel.Movie);
                    }
                    else
                    {
                        _movieService.UpdateMovie(viewModel.Movie);
                    }

                    

                    AddMessage("Movie saved Successfull");

                    return RedirectToAction("Edit", new { id = viewModel.Movie.Id});

                }
                catch (Exception ex)
                {
                    AddError("Error saving: " + ex.Message);

                }

            }
            return View("Edit", viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _movieService.DeleteMovie(id);

                AddMessage("Movie deleted successfully");
            }
            catch(Exception ex)
            {
                AddMessage("Error during delete: " + ex.Message);
            }
            return RedirectToAction("Index","Movies",null);
        }

        //spostato da RoutConfig.cs
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("Movies of {1}/{0}", year, month));
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult UploadFile()
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        var path = System.IO.Path.Combine(Server.MapPath("~/TempFiles"), fileContent.FileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
                AddMessage("File Uploaded Successfully!");
                return Json("File uploaded successfully");
            }
            catch(Exception ex)
            {
                AddError("File upload failed: " + ex.Message);
                return Json("Upload failed");
            }
        }

     

    }
}