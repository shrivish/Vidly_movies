using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;
using Microsoft.EntityFrameworkCore;
using Vidly.Migrations;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private VidlyContext _context;

        public MovieController(VidlyContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).AsEnumerable();

            return View(movies);
        }
        public IActionResult New()
        {
            var genre = _context.Genres.AsEnumerable();
            var newMovie = new MovieFormViewModel
            {
                Movies = new Movie(),
                Genres = genre
            };
            return View("MovieForm", newMovie);
        }
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();
            var editMovie = new MovieFormViewModel
            {
                Movies = movie,
                Genres = _context.Genres.AsEnumerable()
            };
            return View("MovieForm", editMovie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movies = movie,
                    Genres = _context.Genres.AsEnumerable()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }
    }
}
