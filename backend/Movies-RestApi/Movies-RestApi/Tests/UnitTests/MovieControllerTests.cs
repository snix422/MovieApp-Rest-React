using Microsoft.AspNetCore.Mvc;
using Moq;
using Movies_RestApi.Controllers;
using Movies_RestApi.Models;
using Movies_RestApi.Services;
using Xunit;

namespace Movies_RestApi.Tests.UnitTests
{
    public class MovieControllerTests
    {
        private readonly Mock<ILogger<MovieController>> _loggerMock;
        private readonly Mock<IMovieService> _movieServiceMock;
        private readonly MovieController _controller;
        public MovieControllerTests() 
        {
            _loggerMock = new Mock<ILogger<MovieController>>();
            _movieServiceMock = new Mock<IMovieService>();
            _controller = new MovieController(_loggerMock.Object, _movieServiceMock.Object);
        }

        [Fact]
        public async Task GetMovies_ReturnsOkResult_WithListOfMovies()
        {
            var query = new MovieQuery();
            var movies = new List<MovieDTO>()
            {
                new MovieDTO { Id = 1, Title = "Movie 1"},
                new MovieDTO { Id = 2, Title = "Movie 2"}
            };

            var pagedResult = new PagedResult<MovieDTO>(movies, movies.Count, query.pageSize, query.pageNumber);


            _movieServiceMock.Setup(service => service.GetAllMovies(query)).Returns(pagedResult);
            var result = await _controller.GetMovies(query);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<PagedResult<MovieDTO>>(okResult.Value);
            Assert.Equal(2,returnValue.Items.Count());
            Assert.Equal("Movie 2", returnValue.Items[1].Title);
            Assert.Equal("Movie 1", returnValue.Items.First().Title);
            Assert.Contains(returnValue.Items, m => m.Title == "Movie 1");
        }

        [Fact]
        public async Task GetTopRatedMovies_ReturnsOkResult_WithListOfMovies()
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

            _movieServiceMock.Setup(service => service.GetTopRatedMovies()).ReturnsAsync(movies.Take(5));
            var result =  await _controller.GetTopRatedMovies();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<IEnumerable<MovieDTO>>(okResult.Value);
            Assert.Equal(5,returnValue.Count());
            Assert.Equal("Movie 1",returnValue.First().Title);
            Assert.Contains(returnValue, m => m.Rating == 10);  
        }
    }
}
