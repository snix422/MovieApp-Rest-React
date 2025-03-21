using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Dtos;
using Movies_RestApi.Entities;
using Movies_RestApi.Models;
using GenreDTO = Movies_RestApi.Models.GenreDTO;

namespace Movies_RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CategoryController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetCategories()
        {
            var categories = _dataContext.Genres
            .Include(g => g.Movies)
                .ThenInclude(m => m.Director)
             .Include(m => m.Movies)
                .ThenInclude(m => m.ProductionDetails)
            .Include(m => m.Movies)
                .ThenInclude(m => m.Reviews)
                
                
                /*.Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Movies = g.Movies.Select(m => new MovieDTO
                    {
                        Id = m.Id,
                        Title = m.Title
                    }).ToList()
                })*/
                .ToList();



            if (!categories.Any())
            {
                return NotFound("Brak wczytania kategorii");
            }

            var categoriesDTO = _mapper.Map<List<GenreDTO>>(categories);

            return Ok(categoriesDTO);
        }

        [HttpGet("/api/categories/{categoryName}")]
        public async Task<ActionResult<GenreDTO>> GetCategory(string categoryName)
        {
            var category = _dataContext.Genres
                .Where(g => g.Name == categoryName)
                .Include(g => g.Movies)
                /*.Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Movies = g.Movies.Select(m => new MovieDTO
                    {
                        Id = m.Id,
                        Title = m.Title
                    }).ToList()
                })*/
                .ToList();

            if (!category.Any())
            {
                return NotFound("Wystąpił problem z wczytaniem kategorii");
            }

            var categoryDTO = _mapper.Map<GenreDTO>(category);

            return Ok(categoryDTO);
        }

        

    }
}
