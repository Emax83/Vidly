using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewRentalViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        public NewRentalViewModel()
        {
            MovieIds = new List<int>();
        }
    }
}