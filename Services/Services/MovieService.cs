using WebApplication2.Models;
using WebApplication2.Services.ServiceContracts;

namespace WebApplication2.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _db;
        public MovieService(AppDbContext db)
        {
            _db = db;

        }


        public List<Movie> getMoviesByGenreName(string genre)
        {
            var queue = _db.Movies
                .Where(q => q.Genres.Name == genre)
                .ToList();
            return queue;

        }
        public List<Movie> getMoviesOrderedByName()
        {
            var queue = _db.Movies
              .OrderBy(q => q.Name)
              .ToList();
            return queue;

        }

        public List<Movie> getMoviesByGenreID(int id)
        {
            var queue = _db.Movies
         .Where(q => q.genre_id.ToString() == id.ToString())
         .ToList();
            return queue;

        }

    }
}
