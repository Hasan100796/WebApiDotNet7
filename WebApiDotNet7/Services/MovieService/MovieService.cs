using Azure.Core;

namespace WebApiDotNet7.Services.MovieService
{
    public class MovieService:IMovieService
    {
        //public static List<Movie> movies = new List<Movie>{
        //    new Movie
        //    {
        //        Id = 1,
        //        Name = "Pathan",
        //        ActorName = "Sharukh Khan",
        //        Year = 2023
        //    },
        //    new Movie
        //    {
        //        Id = 2,
        //        Name = "KBKJ",
        //        ActorName = "Salman Khan",
        //        Year = 2023
        //    },
        //    new Movie
        //    {
        //        Id = 3,
        //        Name = "PK",
        //        ActorName = "Amir Khan",
        //        Year = 2014
        //    }
        //    };
        private readonly DataContext _context;
        public MovieService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Movie>> AddNewMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return await _context.Movies.ToListAsync();
        }
        public async Task<List<Movie>?> UpdateMovieById(Movie request)
        {
            var movie = await _context.Movies.FindAsync(request.Id);
            if (movie is null)
                return null;
            movie.Name = request.Name;
            movie.ActorName = request.ActorName;
            movie.Year = request.Year;
            await _context.SaveChangesAsync();
            return await _context.Movies.ToListAsync();
        }
        public async Task<List<Movie>?> DeleteMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie is null)
                return null;
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
           return await _context.Movies.ToListAsync();
        }

        public async Task<List<Movie>> GetAllMovie()
        {
            return await _context.Movies.ToListAsync();        
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie is null)
                return null;
            return movie;

        }
    }
}
