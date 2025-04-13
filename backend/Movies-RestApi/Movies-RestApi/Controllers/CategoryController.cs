using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using Movies_RestApi.Exceptions;
using Movies_RestApi.Models;
using Movies_RestApi.Services;
using GenreDTO = Movies_RestApi.Models.GenreDTO;

namespace Movies_RestApi.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : Controller
    {
       
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetCategories()
        {
            
            var categories = await _categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpGet("{categoryName}")]
        public async Task<ActionResult<GenreDTO>> GetCategory(string categoryName)
        {
            
            var category = await _categoryService.GetCategoryByName(categoryName);

            return Ok(category);
        }

        

    }
}
