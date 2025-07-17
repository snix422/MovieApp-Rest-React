using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Movies_RestApi.Controllers;
using Movies_RestApi.Models;
using Movies_RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies_RestApi_Tests
{
    public class MovieControllerTests
    {
        private readonly Mock<IMovieService> _mockMovieService;
        private readonly MovieController _movieController;
        private readonly Mock<ILogger<MovieController>> _logger;

        public MovieControllerTests()
        {
            _logger = new Mock<ILogger<MovieController>>();
            _mockMovieService = new Mock<IMovieService>();
            _movieController = new MovieController(_logger.Object, _mockMovieService.Object);
        }

        [Fact]
        public async Task GetAllMovies_ReturnsOkResult_WithListOfMovies()
        {
            var query = new MovieQuery();
            var movies = new List<MovieDTO> { new MovieDTO { Id = 1, Title = "Movie1" }, new MovieDTO { Id = 2, Title = "Movie2" } };

            var result = new PagedResult<MovieDTO>(movies, movies.Count, 5, 1);

            _mockMovieService.Setup(service => service.GetAllMovies(query)).Returns(result);
            var resultController = await _movieController.GetMovies(query);
            var okResult = Assert.IsType<OkObjectResult>(resultController.Result);
            var returnValue = Assert.IsType<PagedResult<MovieDTO>>(okResult.Value);

            Assert.Equal(2, returnValue.Items.Count);
            Assert.Contains(returnValue.Items, m => m.Title == "Movie1");

        }

        [Fact]
        public async Task GetMovie_ReturnsOkResult_WithMovie()
        {
            var movie = new MovieDTO { Id = 1, Title = "Movie1" };
            _mockMovieService.Setup(service => service.GetMovieById(1)).ReturnsAsync(movie);
            var resultController = await _movieController.GetMovie(1);
            var okResult = Assert.IsType<OkObjectResult>(resultController.Result);
            var returnValue = Assert.IsType<MovieDTO>(okResult.Value);

            Assert.Equal(1, returnValue.Id);
            Assert.Equal("Movie1", returnValue.Title);
        }

        [Fact]
        public async Task GetTopRated_ReturnsOkResult_WithList()
        {
            var movies = new List<MovieDTO>
            {
                new MovieDTO { Id = 1, Title = "Movie 1", Rating = 10},
                new MovieDTO { Id = 1, Title = "Movie 2", Rating = 9},
                new MovieDTO { Id = 1, Title = "Movie 3", Rating = 6},
                new MovieDTO { Id = 1, Title = "Movie 4", Rating = 5},
                new MovieDTO { Id = 1, Title = "Movie 5", Rating = 8},
                new MovieDTO { Id = 1, Title = "Movie 6", Rating = 10},
            };

            _mockMovieService.Setup(service => service.GetTopRatedMovies()).ReturnsAsync(movies.Take(5));
            var resultController = await _movieController.GetTopRatedMovies();
            var okResult = Assert.IsType<OkObjectResult>(resultController.Result);
            var returnValue = Assert.IsType<List<MovieDTO>>(okResult.Value);

            Assert.Equal(5, returnValue.Count);
            Assert.Contains(returnValue, m => m.Title == "Movie1");
        }

        public async Task GetMovie_ReturnsNotFound()
        {
            _mockMovieService.Setup(service => service.GetMovieById(999)).ReturnsAsync((MovieDTO)null);
            var result = await _movieController.GetMovie(999);
            var notFound = Assert.IsType<NotFoundResult>(result.Result);

            Assert.Equal(404, notFound.StatusCode);
        }
    }
}
