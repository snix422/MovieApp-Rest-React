using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using Movies_RestApi.Exceptions;
using Movies_RestApi.Models;
using Movies_RestApi.Services;
using System.Runtime.CompilerServices;
using MovieDTO = Movies_RestApi.Models.MovieDTO;

namespace Movies_RestApi.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;
        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies([FromQuery] MovieQuery query)
        {
            _logger.LogInformation("Pobieranie listy filmów...");

      
     
            var moviesDTO =  _movieService.GetAllMovies(query);

            return Ok(moviesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie([FromRoute]int id)
        {
           var movieDTO = await _movieService.GetMovieById(id);

           return Ok(movieDTO);
        }

        [HttpGet("top-rated")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetTopRatedMovies()
        {
            var topRatedMovies = await _movieService.GetTopRatedMovies();

            return Ok(topRatedMovies);
        }

        [HttpGet("category/{categoryName}")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesByCategory([FromRoute]string categoryName)
        {
          
            var moviesDTO = _movieService.GetMoviesByCategory(categoryName);
            
            return Ok(moviesDTO);  

        }

        [HttpGet("query")]

        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesByQuery([FromQuery]string query)
        {
            if(string.IsNullOrEmpty(query))
            {
                return BadRequest("Fraza szukana nie może być pusta");
            }
            
            var moviesDTO = _movieService.GetMoviesByQuery(query);

            return Ok(moviesDTO);
                
        }

    }
}
