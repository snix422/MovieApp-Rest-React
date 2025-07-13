using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Movies_RestApi;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using Movies_RestApi.Models;
using Movies_RestApi.Services;
using Movies_RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies_RestApi_Tests
{
    public class MovieServiceTest
    {
        private MovieService _movieService;
        private IMapper _mapper;
        private DataContext _context;

        private void SeedDatabase()
        {
            // Upewnij się, że baza jest pusta
            if (_context.Movies.Any()) return;

            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Wikingowie" },
                new Movie { Id = 2, Title = "Wiedźmin" },
                new Movie { Id = 3, Title = "Breaking Bad" }
            };

            _context.Movies.AddRange(movies);
            _context.SaveChanges();
        }

        public MovieServiceTest()
        {
            
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "MovieDbTest")
            .Options;

            _context = new DataContext(options);

            
            SeedDatabase();

            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MovieMappingProfile>(); 
            });
            _mapper = config.CreateMapper();

            
            _movieService = new MovieService(_context, _mapper);
        }

        [Fact]
        public async Task GetAllMovies_WhenSearchPhraseIsW_Returns2Results()
        {
            var query = new MovieQuery { pageNumber = 1, pageSize = 20, searchPhrase = "w" };

            var result = _movieService.GetAllMovies(query);

            Assert.NotNull(result);
            Assert.Equal(2, result.Items.Count);

            var titles = result.Items.Select(m => m.Title).ToList();
            Assert.Contains("Wikingowie", titles);
            Assert.Contains("Wiedźmin", titles);

            Assert.Equal(2, result.TotalItemsCount);
            Assert.Equal(1, result.ItemsFrom);
            Assert.Equal(2, result.ItemsTo);
            Assert.Equal(1, result.TotalPages);
        }
    }
}
