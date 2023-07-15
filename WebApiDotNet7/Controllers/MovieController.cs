using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDotNet7.Services.MovieService;

namespace WebApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovie()
        {
            var movies = await _movieService.GetAllMovie();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            if (movie is null)
                return NotFound("Sorry, but this movie dosen't exist.");
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddNewMovie(Movie movie)
        {
            var movies = await _movieService.AddNewMovie(movie);
            if(movies is null)
                return NotFound("Sorry, but this movie dosen't exist.");
            return Ok(movies);
        }

        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovieById(Movie request)
        {
            var movies = await _movieService.UpdateMovieById(request);
            if (movies is null)
                return NotFound("Sorry, but this movie dosen't exist.");
            return Ok(movies);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> DeleteMovieById(int id)
        {
            var movies = await _movieService.DeleteMovieById(id);
            if (movies is null)
                return NotFound("Sorry, but this movie dosen't exist.");
            return Ok(movies);
        }
    }
}
