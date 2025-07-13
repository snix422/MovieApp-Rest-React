using Movies_RestApi.Models;

namespace Movies_RestApi.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieDTO> GetMovieById(int id);
        PagedResult<MovieDTO> GetAllMovies(MovieQuery query);
        Task<IEnumerable<MovieDTO>> GetTopRatedMovies();
        IEnumerable<MovieDTO> GetMoviesByQuery(string query);
        IEnumerable<MovieDTO> GetMoviesByCategory(string category);
    }
}
