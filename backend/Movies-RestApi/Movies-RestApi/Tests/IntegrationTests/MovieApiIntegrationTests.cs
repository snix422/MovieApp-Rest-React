using Movies_RestApi.Models;
using System.Net;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Movies_RestApi.Tests.IntegrationTests
{
    public class MovieApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public MovieApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllMovies_ReturnsOkAndList()
        {
            var response = await _httpClient.GetAsync("api/movie");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var movies = await response.Content.ReadFromJsonAsync<List<MovieDTO>>();
            Assert.NotNull(movies);
        }

        [Fact]
        public async Task GetMovie_ReturnsOkAndMovie()
        {
            var response = await _httpClient.GetAsync("api/movie/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var movies = await response.Content.ReadFromJsonAsync<MovieDTO>();
            Assert.NotNull(movies);
        }

        [Fact]
        public async Task GetTopMovies_ReturnsOkAndMovies()
        {
            var response = await _httpClient.GetAsync("api/movie/top-rated");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var movies = await response.Content.ReadFromJsonAsync<List<MovieDTO>>();
            Assert.NotNull(movies);
            Assert.Equal(5, movies.Count());
        }

        [Fact]
        public async Task GetMovie_ReturnsFailedAndNull()
        {
            var response = await _httpClient.GetAsync("api/movie/9292929");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            var movies = await response.Content.ReadFromJsonAsync<MovieDTO>();
            Assert.Null(movies);
        }


    }
}
