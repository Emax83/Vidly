using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }
        [NotMapped]
        public List<Movie> Movies { get; set; }
    }
}