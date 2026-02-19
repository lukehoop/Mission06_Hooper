using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Hooper.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Hooper.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        // Constructor - inject database context
        public HomeController(MovieContext context)
        {
            _context = context;
        }

        // Home page
        public IActionResult Index()
        {
            return View();
        }

        // GET: Show form to add new movie
        public IActionResult AddMovies()
        {
            // Load dropdown data
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        // POST: Save new movie to database
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            // Reload dropdowns if validation fails
            ViewBag.Categories = _context.Categories.ToList();
            return View("AddMovies", movie);
        }

        // GET: Display all movies in a table
        public IActionResult MovieList()
        {
            // Include Category to show category name instead of ID
            var movies = _context.Movies
                .Include(m => m.Category)
                .ToList();
            return View(movies);
        }

        // GET: Show edit form for a movie
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            // Load dropdown data
            ViewBag.Categories = _context.Categories.ToList();
            return View(movie);
        }

        // POST: Save edited movie
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            // Reload dropdowns if validation fails
            ViewBag.Categories = _context.Categories.ToList();
            return View(movie);
        }

        // GET: Show delete confirmation page
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Confirm and delete movie
        [HttpPost]
        public IActionResult DeleteConfirmed(int MovieId)
        {
            var movie = _context.Movies.Find(MovieId);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }

        // Static page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}