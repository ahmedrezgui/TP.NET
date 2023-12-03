using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppDbContext _db;
        public GenreController(AppDbContext db)
        {
           this._db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
