using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Dtos;
using Movies_RestApi.Entities;

namespace Movies_RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;

        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetCategories()
        {
            var categories = _dataContext.Genres
            .Include(g => g.Movies)
                .Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Movies = g.Movies.Select(m => new MovieDTO
                    {
                        Id = m.Id,
                        Title = m.Title
                    }).ToList()
                })
                .ToList();

            if (!categories.Any())
            {
                return NotFound("Brak wczytania kategorii");
            }

            return Ok(categories);
        }

        [HttpGet("/api/categories/{categoryName}")]
        public async Task<ActionResult<GenreDTO>> GetCategory(string categoryName)
        {
            var category = _dataContext.Genres
                .Where(g => g.Name == categoryName)
                .Include(g => g.Movies)
                .Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Movies = g.Movies.Select(m => new MovieDTO
                    {
                        Id = m.Id,
                        Title = m.Title
                    }).ToList()
                })
                .ToList();

            if (!category.Any())
            {
                return NotFound("Wystąpił problem z wczytaniem kategorii");
            }

            return Ok(category);
        }

        

    }
}
