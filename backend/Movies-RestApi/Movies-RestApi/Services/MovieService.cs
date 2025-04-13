using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using Movies_RestApi.Exceptions;
using Movies_RestApi.Models;
using System.Collections;

namespace Movies_RestApi.Services
{
    public interface IMovieService
    {
        Task<MovieDTO> GetMovieById(int id);
        PagedResult<MovieDTO> GetAllMovies(MovieQuery query);
        IEnumerable<MovieDTO> GetMoviesByQuery(string query);
        IEnumerable<MovieDTO> GetMoviesByCategory(string category);
        Task<IEnumerable<MovieDTO>> GetTopRatedMovies();
    }
    public class MovieService : IMovieService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public MovieService(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MovieDTO> GetMovieById(int id)
        {
            var movie = await _dbContext.Movies
                       .Include(m => m.Genre)
                       .Include(m => m.Director)
                       .Include(m => m.Actors)
                       .Include(m => m.ProductionDetails)
                       .Include(m => m.Reviews)
                       .FirstOrDefaultAsync(m => m.Id == id);
               
            if (movie is null) throw new NotFoundException("Movie not found");


            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return movieDTO;
        }

        public PagedResult<MovieDTO> GetAllMovies(MovieQuery query)
        {

            var baseQuery = _dbContext.Movies
                        .Include(m => m.Genre)
                        .Include(m => m.Director) 
                        .Include(m => m.ProductionDetails)
                        .Include(m => m.Reviews)
                        .Include(m => m.Actors)
                        .Where(m => query.searchPhrase == null || (m.Title.ToLower().Contains(query.searchPhrase.ToLower())));


            var movies = baseQuery
                        .Skip(query.pageSize * (query.pageNumber -1))
                        .Take(query.pageSize)
                        .ToList();

            if (!movies.Any()) throw new NotFoundException("Movies not found");

            var moviesDTO = _mapper.Map<List<MovieDTO>>(movies);

            var totalMoviesCount = baseQuery.Count();

            var result = new PagedResult<MovieDTO>(moviesDTO, totalMoviesCount, query.pageSize, query.pageNumber);

            return result;
            
           
        }

        public async Task<IEnumerable<MovieDTO>> GetTopRatedMovies()
        {
            var topRatedMovies = await _dbContext.Movies
                                    .Include(m => m.Genre)
                                    .Include(m => m.Director)
                                    .Include(m => m.Actors)
                                    .Include(m => m.ProductionDetails)
                                    .Include(m => m.Reviews)
                                    .OrderByDescending(m => m.Rating)
                                    .Take(5)
                                    .ToListAsync();

            if (!topRatedMovies.Any()) throw new NotFoundException("Nie znaleziono filmów");

            var topRatedDTO = _mapper.Map<List<MovieDTO>>(topRatedMovies);

            return topRatedDTO;
        }

        public IEnumerable<MovieDTO> GetMoviesByQuery(string query)
        {
            
            var movies = _dbContext.Movies
                .Where(m => EF.Functions.Like(m.Title.ToLower(), $"%{query.ToLower()}%"))
                        .Include(m => m.Genre)
                        .Include(m => m.Director)
                        .Include(m => m.Actors)
                        .Include(m => m.ProductionDetails)
                        .Include(m => m.Reviews)
                .ToList();


            if (movies is null) throw new NotFoundException("Nie znaleziono filmów");
          
            var moviesDTO = _mapper.Map<List<MovieDTO>>(movies);

            return moviesDTO;
        }

        public IEnumerable<MovieDTO> GetMoviesByCategory(string category)
        {
            var movies = _dbContext.Movies
                            .Include(m => m.Genre)  
                            .Where(m => m.Genre != null && m.Genre.Name.ToLower() == category.ToLower())  
                            .ToList();

            Console.WriteLine(movies);

            var moviesDTO = _mapper.Map<List<MovieDTO>>(movies);

            return moviesDTO;

        }
    }
    }

