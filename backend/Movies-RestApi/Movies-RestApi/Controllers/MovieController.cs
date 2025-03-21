using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Dtos;
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
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;
        public MovieController(DataContext dataContext, IMapper mapper, ILogger<MovieController> logger, IMovieService movieService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
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
           var movieDTO = _movieService.GetMovieById(id);

           return Ok(movieDTO);
        }

        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesByCategory([FromQuery]string category)
        {

           
            if (string.IsNullOrEmpty(category))
            {
                return BadRequest("Kategoria nie może posiadać");
            }


            var moviesDTO = _movieService.GetMoviesByCategory(category);
            
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
