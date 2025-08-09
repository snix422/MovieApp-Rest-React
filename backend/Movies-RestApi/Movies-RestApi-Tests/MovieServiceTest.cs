using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Moq;
using Movies_RestApi;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using Movies_RestApi.Exceptions;
using Movies_RestApi.Models;
using Movies_RestApi.Services;
using Movies_RestApi.Services.Interfaces;
using NuGet.Frameworks;
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
            if (_context.Movies.Any()) return;

            // Przykładowe wspólne obiekty dla wielu filmów
            var genre = new Genre { Id = 1, Name = "Dramat" };
            var director = new Director { Id = 1, FirstName = "Jan", LastName = "Kowalski" };
            var actor1 = new Actor { Id = 1, FirstName = "Aktor A", LastName = "Ab" };
            var actor2 = new Actor { Id = 2, FirstName = "Aktor B", LastName = "Ba" };
            var productionDetails = new ProductionDetails { Id = 1, Budget = 1000000, Studio = "Polska", Duration = 120 };

            _context.Genres.Add(genre);
            _context.Directors.Add(director);
            _context.Actors.AddRange(actor1, actor2);
            _context.ProductionDetails.Add(productionDetails);
            _context.SaveChanges();

            var movies = new List<Movie>
    {
        new Movie
        {
            Id = 1,
            Title = "Wikingowie",
            ImageUrl = "https://example.com/wikingowie.jpg",
            Genre = genre,
            Director = director,
            ProductionDetails = productionDetails,
            Actors = new List<Actor> { actor1, actor2 },
            Reviews = new List<Review>
            {
                new Review { Id = 1, Comment = "Świetny film!", Rating = 5, AuthorName="Test123" },
                new Review { Id = 2, Comment = "Dobrze się oglądało", Rating = 4 , AuthorName = "Test123" }
            },
            Rating = 5,
        },
        new Movie
        {
            Id = 2,
            Title = "Wiedźmin",
            ImageUrl = "https://example.com/wiedzmin.jpg",
            Genre = genre,
            Director = director,
            ProductionDetails = productionDetails,
            Actors = new List<Actor> { actor1 },
            Reviews = new List<Review>
            {
                new Review { Id = 3, Comment = "Lepszy niż książka!", Rating = 4 , AuthorName = "TestAbc"}
            },
            Rating = 3,
        },
        new Movie
        {
            Id = 3,
            Title = "Breaking Bad",
            ImageUrl = "https://example.com/breakingbad.jpg",
            Genre = genre,
            Director = director,
            ProductionDetails = productionDetails,
            Actors = new List<Actor> { actor2 },
            Reviews = new List<Review>(),
            Rating = 4
        },
         new Movie
        {
            Id = 4,
            Title = "Depth Q",
            ImageUrl = "https://example.com/depthq.jpg",
            Genre = genre,
            Director = director,
            ProductionDetails = productionDetails,
            Actors = new List<Actor> { actor2 },
            Reviews = new List<Review>(),
            Rating = 4
        },
        new Movie
        {
            Id = 5,
            Title = "Gra o tron",
            ImageUrl = "https://example.com/breakingbad.jpg",
            Genre = genre,
            Director = director,
            ProductionDetails = productionDetails,
            Actors = new List<Actor> { actor2 },
            Reviews = new List<Review>(),
            Rating = 4
        },
        new Movie
        {
            Id = 6,
            Title = "Dom z papieru",
            ImageUrl = "https://example.com/breakingbad.jpg",
            Genre = genre,
            Director = director,
            ProductionDetails = productionDetails,
            Actors = new List<Actor> { actor2 },
            Reviews = new List<Review>(),
            Rating = 5
        }
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
            var query = new MovieQuery { pageNumber = 1, pageSize = 20, searchPhrase = "W" };

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

        [Fact]
        public async Task GetAllMovies_WhenSearchPhraseIsNull_Return6Results()
        {
            var query = new MovieQuery { pageNumber = 1, pageSize = 5, searchPhrase = "" };
            var result = _movieService.GetAllMovies(query);
            Assert.NotNull(result);
            Assert.Equal(6, result.Items.Count);
            var titles = result.Items.Select(m => m.Title).ToList();
            Assert.Contains("Wikingowie", titles);
            Assert.Contains("Gra o tron", titles);

            Assert.Equal(6, result.TotalItemsCount);
            Assert.Equal(1, result.ItemsFrom);
            Assert.Equal(6, result.ItemsTo);
            Assert.Equal(2, result.TotalPages);
        }

        [Fact]
        public async Task GetTopRated_Return5Results()
        {
            var result = await _movieService.GetTopRatedMovies();
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
            var titles = result.Select(m => m.Title).ToList();
            Assert.Contains("Wikingowie", titles);
            Assert.Contains("Dom z papieru", titles);
        }

        [Fact]
        public async Task GetMovieById_Return1ResultWithId1()
        {
            var result = await _movieService.GetMovieById(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Wikingowie", result.Title);
        }

        [Fact]
        public async Task GetMovieById_ReturnFailedWithNotExistId()
        {
            var nonExistendId = 55555;
            await Assert.ThrowsAsync<NotFoundException>(() => _movieService.GetMovieById(nonExistendId));
        } 
    }
}
