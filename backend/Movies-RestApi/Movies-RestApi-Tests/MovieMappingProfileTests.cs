using AutoMapper;
using FluentAssertions;
using Movies_RestApi.Entities;
using Movies_RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies_RestApi_Tests
{
    public class MovieMappingProfileTests
    {
        [Fact]
        public void MappingProfile_ShouldMapMovieToMovieDTO()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new Movies_RestApi.MovieMappingProfile()));
            var mapper = configuration.CreateMapper();
            var dto = new Movie
            {
                Id = 1,
                Title = "Title",
                Rating = 5,
                Genre = new Genre { Id = 1, Name = "Comedy" },
                ProductionDetails = new ProductionDetails { Id = 1, Budget = 100000, Duration = 120, Studio = "Disney" },
                Director = new Director { Id = 1, FirstName = "John", LastName = "Travolta" }
            };
            var result = mapper.Map<MovieDTO>(dto);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Title.Should().Be("Title");
            result.Rating.Should().Be(5);
            result.CategoryName.Should().Be("Comedy");
            result.Budget.Should().Be(100000);
            result.Duration.Should().Be(120);
            result.Studio.Should().Be("Disney");
        }

    }
}
