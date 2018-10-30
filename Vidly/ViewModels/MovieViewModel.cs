using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        //https://stackoverflow.com/questions/21677038/mvc-upload-file-with-model-second-parameter-posted-file-is-null
        public HttpPostedFileBase Cover { get; set; }
        public HttpPostedFileBase Backdrop { get; set; }
    }
}