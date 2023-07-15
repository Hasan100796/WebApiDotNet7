namespace WebApiDotNet7.Services.MovieService
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMovie();
        Task<Movie?> GetMovieById(int id);
        Task<List<Movie>> AddNewMovie(Movie movie);
        Task<List<Movie>?> UpdateMovieById(Movie request);
        Task<List<Movie>?> DeleteMovieById(int id);
    }
}
