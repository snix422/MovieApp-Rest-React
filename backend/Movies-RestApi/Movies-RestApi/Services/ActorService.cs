using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using Movies_RestApi.Exceptions;

namespace Movies_RestApi.Services
{
    public interface IActorService
    {
        Task<List<Actor>> GetAllActors();
    }
    public class ActorService : IActorService
    {
        private readonly DataContext _dbContext;
        public ActorService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Actor>> GetAllActors()
        {
            var actors = await _dbContext.Actors
                .Include(a => a.Movies)
                .ToListAsync();

            if (actors.Any()) throw new NotFoundException("Nie znaleziono aktorów");

            return actors;
        }
    }
}
