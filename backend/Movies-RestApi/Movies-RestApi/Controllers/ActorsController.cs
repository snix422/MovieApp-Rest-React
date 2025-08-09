using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using Movies_RestApi.Services;

namespace Movies_RestApi.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {

            var actors = await _actorService.GetAllActors();

            return Ok(actors);
        }

    }
}
