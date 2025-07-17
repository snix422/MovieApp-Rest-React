using Microsoft.AspNetCore.Mvc.Testing;
using Movies_RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Movies_RestApi_Tests
{
    public class MovieApiIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;

        public MovieApiIntegrationTests(CustomWebApplicationFactory applicationFactory)
        {
            _httpClient = applicationFactory.CreateClient();
        }

        [Fact]
        public async Task GetAllMovies_ReturnsOkAndList()
        {
            var response = await _httpClient.GetAsync("/api/movie");
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadFromJsonAsync<List<MovieDTO>>();
            Assert.NotNull(movies);
            Assert.True(movies.Any());
        }

        public async Task GetMovie_ReturnOkAndMovie()
        {
            var response = await _httpClient.GetAsync("/api/movie/1");
            response.EnsureSuccessStatusCode();
            var movie = await response.Content.ReadFromJsonAsync<MovieDTO>();
            Assert.NotNull(movie);
            Assert.Equal("Inception", movie.Title);
        }

        public async Task GetTopMovies_ReturnsOkAnd5Results()
        {
            var response = await _httpClient.GetAsync("api/movie/top-rated");
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadFromJsonAsync<List<MovieDTO>>();
            Assert.NotNull(movies);
            Assert.Equal(5, movies.Count());
        }

        [Fact]
        public async Task GetMovie_ReturnsFailed()
        {
            var response = await _httpClient.GetAsync("api/movie/786768789");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            var movies = await response.Content.ReadFromJsonAsync<MovieDTO>();
            Assert.Null(movies);    
        }

        [Fact]
        public async Task GetAllMovies_ReturnsFailed()
        {
            var response = await _httpClient.GetAsync("api/movie111");
            Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        }

    }


}
