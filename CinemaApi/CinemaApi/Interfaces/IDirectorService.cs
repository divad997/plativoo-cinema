using CinemaCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Interfaces
{
    public interface IDirectorService
    {
        Task<Director> CreateDirectorAsync(Director director);
        Task<List<Director>> GetAllDirectorsAsync();
        Task<Director> GetDirectorByIdAsync(Guid id);
        Task<bool> EditDirectorAsync(Director director);
        Task<bool> DeleteDirectorAsync(Guid actorId);
    }
}
