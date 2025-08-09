using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using Movies_RestApi.Models;
using NLog.Config;
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
        private readonly CustomWebApplicationFactory _customWebApplicationFactory;

        public MovieApiIntegrationTests(CustomWebApplicationFactory customWebApplicationFactory)
        {
            var dbName = Guid.NewGuid().ToString();
            _customWebApplicationFactory = new CustomWebApplicationFactory(dbName);

            _httpClient = _customWebApplicationFactory.CreateClient();

            // Przygotuj bazę danych i dane testowe
            using var scope = _customWebApplicationFactory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Movies.AddRange(
                new Movie { Id = 1, Title = "Inception", Rating = 9, ImageUrl = "inception" },
                new Movie { Id = 2, Title = "Interstellar", Rating = 8, ImageUrl = "interstellar" },
                new Movie { Id = 3, Title = "Tenet", Rating = 7, ImageUrl = "Tenet" },
                new Movie { Id = 4, Title = "Dunkirk", Rating = 7, ImageUrl = "Dunkirk" },
                new Movie { Id = 5, Title = "Batman Begins", Rating = 9, ImageUrl = "Batman" },
                new Movie { Id = 6, Title = "The Dark Knight", Rating = 10, ImageUrl = "Dark Knight" }
            );
            db.SaveChanges();
        }

        [Fact]
        public async Task GetAllMovies_ReturnsOkAndList()
        {
            var response = await _httpClient.GetAsync("/api/movie");
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadFromJsonAsync<List<MovieDTO>>();
            Assert.NotNull(movies);
            Assert.True(movies.Any());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetMovie_ReturnOkAndMovie()
        {
            var response = await _httpClient.GetAsync("/api/movie/1");
            response.EnsureSuccessStatusCode();
            var movie = await response.Content.ReadFromJsonAsync<MovieDTO>();
            Assert.NotNull(movie);
            Assert.Equal("Inception", movie.Title);
        }

        [Fact]
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
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAllMovies_ReturnsFailed()
        {
            var response = await _httpClient.GetAsync("api/movie111");
            Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        }

    }


}
