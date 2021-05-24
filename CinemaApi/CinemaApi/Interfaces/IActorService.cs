using CinemaCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Interfaces
{
    public interface IActorService
    {
        Task<Actor> CreateActorAsync(Actor actor);
        Task<List<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(Guid id);
        Task<bool> EditActorAsync(Actor actor);
        Task<bool> DeleteActorAsync(Guid actorId);
    }
}
