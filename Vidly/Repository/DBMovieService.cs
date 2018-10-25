using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Infrastracture;

namespace Vidly.Repository
{
    public class DBMovieService : IMovieService
    {
        private readonly DBHelper _dBHelper;
        public DBMovieService(DBHelper db)
        {
            _dBHelper = db;
        }

        public bool AddMovie(Movie movie)
        {
            _dBHelper.SqlParameters.Clear();
            _dBHelper.SqlParameters.AddRange(_dBHelper.GetParametersFromObject(movie));
            _dBHelper.ExecuteQueryFromStoredProcedure("");
            return true;
        }

        public bool DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetGenres()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMovies()
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}