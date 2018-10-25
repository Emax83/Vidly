using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using System.Data.Entity;
using Vidly.Helpers;
using Vidly.Infrastracture;

namespace Vidly.Repository
{
    public class EFMovieService : IMovieService
    {
        private readonly ApplicationDbContext _dbContext;
        public EFMovieService(ApplicationDbContext context)
        {
            _dbContext = context;   
        }

        public bool AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateMovie(Movie movie)
        {
            var dbMovie = GetMovie(movie.Id);

            Mapper.Map(movie, dbMovie);

            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteMovie(int id)
        {
            var movie = GetMovie(id);
            if (movie == null)
                return false;

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _dbContext.Genres.ToList();
        }

        public Movie GetMovie(int id)
        {
            return _dbContext.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.Include(c => c.Genre).ToList();
        }

        
    }
}