using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Infrastracture
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(int id);
        bool AddMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(int id);
        
        IEnumerable<Genre> GetGenres();
    }
}
