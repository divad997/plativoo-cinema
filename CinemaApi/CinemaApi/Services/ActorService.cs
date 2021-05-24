using CinemaApi.Interfaces;
using CinemaCore.Models;
using CinemaInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class ActorService : IActorService
    {
        private readonly CinemaDbContext _context;

        public ActorService(CinemaDbContext context)
        {
            _context = context;
        }
        public async Task<Actor> CreateActorAsync(Actor actor)
        {
            if (_context.Actors == null)
                throw new Exception("Couldn't retrieve the actors!");
            else
            {
                Actor newActor = new Actor(actor.FirstName, actor.LastName, actor.DateOfBirth);

                _context.Actors.Add(newActor);
                await _context.SaveChangesAsync();

                return newActor;
            }
        }

        public async Task<List<Actor>> GetAllActorsAsync()
        {
            var actors = await _context.Actors
                .Include(a => a.Movies)
                .ToListAsync();

            if (actors == null)
                throw new Exception("Couldn't retrieve the actors!");
            else
                return actors;
        }

        public async Task<Actor> GetActorByIdAsync(Guid id)
        {
            var actor = await _context.Actors
                .Include(a => a.Movies)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (actor == null)
                throw new Exception("Couldn't retrieve the actor!");
            else
                return actor;
        }

        public async Task<bool> EditActorAsync(Actor actor)
        {
            var editedActor = await _context.Actors.FindAsync(actor.Id);

            editedActor.Update(actor);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteActorAsync(Guid actorId)
        {
            var actor = await _context.Actors.FindAsync(actorId);

            if (actor == null)
                throw new Exception("Actor with given id doesn't exist!");
            else
            {
                _context.Actors.Remove(actor);
                return await _context.SaveChangesAsync() == 1;
            }
        }
    }
}
