using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Exceptions;
using Movies_RestApi.Models;

namespace Movies_RestApi.Services
{
    public interface IMovieService
    {
        MovieDTO GetMovieById(int id);
        PagedResult<MovieDTO> GetAllMovies(MovieQuery query);
        IEnumerable<MovieDTO> GetMoviesByQuery(string query);
        IEnumerable<MovieDTO> GetMoviesByCategory(string category);
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

        public MovieDTO GetMovieById(int id)
        {
            var movie = _dbContext.Movies
                       .Include(m => m.Genre)
                       .Include(m => m.Director)
                       .Include(m => m.Actors)
                       .Include(m => m.ProductionDetails)
                       .Include(m => m.Reviews)
                       .FirstOrDefault(m => m.Id == id);
               /*.Select(m => new MovieDTO
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
                   Reviews = m.Reviews,
                   ImgUrl= m.ImageUrl
               })*/
               

            if (movie is null) throw new NotFoundException("Movie not found");


            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return movieDTO;
        }

        public PagedResult<MovieDTO> GetAllMovies(MovieQuery query)
        {
            var baseQuery = _dbContext.Movies
                        .Include(m => m.Genre)
                        .Include(m => m.Director)
                        .Include(m => m.Actors)
                        .Include(m => m.ProductionDetails)
                        .Include(m => m.Reviews)
                        .Where(m => query.searchPhrase == null || (m.Title.ToLower().Contains(query.searchPhrase.ToLower())));


            var movies = baseQuery
                        .Skip(query.pageSize * (query.pageNumber -1))
                        .Take(query.pageSize)
                        .ToList();

            if (movies is null) throw new NotFoundException("Movies not found");

            var moviesDTO = _mapper.Map<List<MovieDTO>>(movies);

            var totalMoviesCount = baseQuery.Count();

            var result = new PagedResult<MovieDTO>(moviesDTO,totalMoviesCount, query.pageSize, query.pageNumber);

            return result;
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
                /*.Select(m => new MovieDTO
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
                    Reviews = m.Reviews,
                    ImgUrl = m.ImageUrl
                })*/
                .ToList();


            //if (movies is null) throw new NotFoundException("Nie znaleziono filmów");
          

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

