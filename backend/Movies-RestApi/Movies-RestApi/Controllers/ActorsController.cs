using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;

namespace Movies_RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private readonly DataContext _dataContext;
        public ActorsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            var actors = await _dataContext.Actors.ToListAsync();
            if(!actors.Any())
            {
                return NotFound("Wystąpił problem z pobraniem aktorów");
            }
            return Ok(actors);
        }

    }
}
