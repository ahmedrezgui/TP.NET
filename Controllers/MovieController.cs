using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _db;
        public MovieController(AppDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            var movies = _db.Movies.ToList();
            return View(movies);
        }

        public IActionResult Edit(int id)
        {
            return Content("Test Id" + id);

        }
        public IActionResult ByRelease(int year, int month)
        {
            return Content("Movie released in " + month + "/" + year);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            movie.Id = new Guid();
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _db.Movies
                .Include(m => m.Genres)
                .Include(m => m.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,MovieAdded,genre_id")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the movie entity in the database
                    _db.Update(movie);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to the action of your choice
            }

            return View(movie);
        }

        private bool MovieExists(Guid id)
        {
            return _db.Movies.Any(e => e.Id == id);
        }

        public IActionResult Delete(Movie movie)
        {
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
            return (RedirectToAction(nameof(Index)));

        }


    }
}
