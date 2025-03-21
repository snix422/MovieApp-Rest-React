using AutoMapper;
using Movies_RestApi.Entities;
using Movies_RestApi.Models;

namespace Movies_RestApi
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ForMember(m => m.CategoryName, c => c.MapFrom(s => s.Genre.Name))
                .ForMember(m => m.Budget, c => c.MapFrom(s => s.ProductionDetails.Budget))
                .ForMember(m => m.Duration, c => c.MapFrom(s => s.ProductionDetails.Duration))
                .ForMember(m => m.Studio, c => c.MapFrom(s => s.ProductionDetails.Studio))
                .ForMember(m => m.DirectorName, c => c.MapFrom(s => s.Director.FirstName))
                .ForMember(m => m.DirectorSurname, c => c.MapFrom(s => s.Director.LastName));

            CreateMap<Review, ReviewDTO>()
                .ForMember(m => m.MovieTitle, c => c.MapFrom(s => s.Movie.Title));

            CreateMap<Genre, GenreDTO>();
                //.ForMember(m => m.CategoryName, c => c.MapFrom(s => s.Name)); 
        }
    }
}
