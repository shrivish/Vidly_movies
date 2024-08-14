using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Humanizer.Localisation;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public Genres Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        public int NumberAvailable { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

    }
}
