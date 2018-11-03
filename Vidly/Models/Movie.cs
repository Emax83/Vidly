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
        //[DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date added")]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(0,1000,ErrorMessage ="Min. 0€")]
        //[DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Available")]
        public int NumberAvailable { get; set; }

        [Required]
        [Range(1,1000,ErrorMessage ="Select genre")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public string Cover {
            get {
                return string.Format("{0}/{1}",Id,"Cover.jpg");
            }
        }
        public string Backdrop {
            get {
                return string.Format("{0}/{1}", Id, "Backdrop.jpg");
            }
        }

    }
}