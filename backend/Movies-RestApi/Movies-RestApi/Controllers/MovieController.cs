using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Dtos;
using Movies_RestApi.Entities;

namespace Movies_RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly DataContext _dataContext;
        public MovieController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _dataContext.Movies
                        .Include(m => m.Genre)
                        .Include(m => m.Director)
                        .Include(m => m.Actors)
                        .Include(m => m.ProductionDetails)
                        .Include(m => m.Reviews)
                        .Select(m => new MovieDTO
                        {
                            Id = m.Id,
                            Title = m.Title,
                            Genre = m.Genre.Name,
                            Director = m.Director != null ? $"{m.Director.FirstName} {m.Director.LastName}" : null,
                            Actors = m.Actors.Select(a => new ActorDTO
                            {
                                FullName = $"{a.FirstName} {a.LastName}"
                            }).ToList(),
                            ProductionDetails = m.ProductionDetails,
                            Reviews = m.Reviews
                        })
                        .ToListAsync();

            return Ok(movies);
        }

        [HttpGet("movie/{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _dataContext.Movies
                        .Include(m => m.Genre)
                        .Include(m => m.Director)
                        .Include(m => m.Actors)
                        .Include(m => m.ProductionDetails)
                        .Include(m => m.Reviews)
                        .Select(m => new MovieDTO
                        {
                            Id = m.Id,
                            Title = m.Title,
                            Genre = m.Genre.Name,
                            Director = m.Director != null ? $"{m.Director.FirstName} {m.Director.LastName}" : null,
                            Actors = m.Actors.Select(a => new ActorDTO
                            {
                                FullName = $"{a.FirstName} {a.LastName}"
                            }).ToList(),
                            ProductionDetails = m.ProductionDetails,
                            Reviews = m.Reviews
                        })
                .FirstOrDefaultAsync(m => m.Id == id);

            if(movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("movies/category/{category}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return BadRequest("Kategoria nie może posiadać");
            }

            var movies = await _dataContext.Movies
                        .Include(m => m.Genre)
                        .Include(m => m.Director)
                        .Include(m => m.Actors)
                        .Include(m => m.ProductionDetails)
                        .Include(m => m.Reviews)
                        .Select(m => new MovieDTO
                        {
                            Id = m.Id,
                            Title = m.Title,
                            Genre = m.Genre.Name,
                            Director = m.Director != null ? $"{m.Director.FirstName} {m.Director.LastName}" : null,
                            Actors = m.Actors.Select(a => new ActorDTO
                            {
                                FullName = $"{a.FirstName} {a.LastName}"
                            }).ToList(),
                            ProductionDetails = m.ProductionDetails,
                            Reviews = m.Reviews
                        })
                        .Where(m => EF.Functions.Like(m.Genre, $"%{category}%"))
                            .ToListAsync();

            if (!movies.Any())
            {
                return NotFound("Nie znaleziono filmu dla danej kategorii");
            }

            return Ok(movies);  

        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByQuery(string query)
        {
            if(string.IsNullOrEmpty(query))
            {
                return BadRequest("Fraza szukana nie może być pusta");
            }
            var movies = await _dataContext.Movies
                .Where(m => EF.Functions.Like(m.Title.ToLower(), $"%{query.ToLower()}%"))
                        .Include(m => m.Genre)
                        .Include(m => m.Director)
                        .Include(m => m.Actors)
                        .Include(m => m.ProductionDetails)
                        .Include(m => m.Reviews)
                        .Select(m => new MovieDTO
                        {
                            Id = m.Id,
                            Title = m.Title,
                            Genre = m.Genre.Name,
                            Director = m.Director != null ? $"{m.Director.FirstName} {m.Director.LastName}" : null,
                            Actors = m.Actors.Select(a => new ActorDTO
                            {
                                FullName = $"{a.FirstName} {a.LastName}"
                            }).ToList(),
                            ProductionDetails = m.ProductionDetails,
                            Reviews = m.Reviews
                        })
                .ToListAsync();

            if (!movies.Any())
            {
                return NotFound("Nie znaleziono filmu dla danej frazy");
            }

            return Ok(movies);
                
        }

    }
}
