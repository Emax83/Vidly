using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Date of Release")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date added")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(0,1000,ErrorMessage ="Min. 0€")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Availability")]
        public int NumberInStock { get; set; }

        [Required]
        [Range(1,1000,ErrorMessage ="Select genre")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

    }
}