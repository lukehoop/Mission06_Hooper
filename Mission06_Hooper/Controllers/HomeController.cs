using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Hooper.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; // Add this for List<T>
using System.Linq; // Add this for ToList()

namespace Mission06_Hooper.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Display the form
        public IActionResult AddMovies()
        {
            // Pass ONLY ratings for dropdown - Categories removed
            ViewBag.Ratings = _context.Ratings?.ToList() ?? new List<Rating>();
            return View();
        }

        // POST: Handle form submission
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // If validation fails, reload the form with ratings data
            ViewBag.Ratings = _context.Ratings?.ToList() ?? new List<Rating>();
            return View("AddMovies", movie);
        }

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