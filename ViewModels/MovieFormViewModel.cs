using Vidly.Models;
using System;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genres> Genres { get; set; }
        public Movie Movies { get; set; }
    }
}
