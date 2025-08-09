using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Exceptions;
using Movies_RestApi.Models;

namespace Movies_RestApi.Services
{
    public interface ICategoryService
    {
        Task<List<GenreDTO>> GetAllCategories();
        Task<GenreDTO> GetCategoryByName(string categoryName);
    }

    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public CategoryService(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GenreDTO>> GetAllCategories()
        {
            var categories = await _dbContext.Genres
            .Include(g => g.Movies)
                .ThenInclude(m => m.Director)
             .Include(m => m.Movies)
                .ThenInclude(m => m.ProductionDetails)
            .Include(m => m.Movies)
                .ThenInclude(m => m.Reviews)
                .ToListAsync();

            if (!categories.Any()) throw new NotFoundException("Nie znaleziono kategorii");

            var categoriesDTO = _mapper.Map<List<GenreDTO>>(categories);

            return categoriesDTO;
        }

        public async Task<GenreDTO> GetCategoryByName(string categoryName)
        {
            var category = await _dbContext.Genres
               .Where(g => g.Name == categoryName)
               .Include(g => g.Movies)
               .ToListAsync();

            if (!category.Any()) throw new NotFoundException("Nie znaleziono wybranej kategorii");

            var categoryDTO = _mapper.Map<GenreDTO>(category);

            return categoryDTO;
        }
    }
}
