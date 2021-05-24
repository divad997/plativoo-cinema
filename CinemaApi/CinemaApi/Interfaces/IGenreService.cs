using CinemaCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Interfaces
{
    public interface IGenreService
    {
        Task<Genre> CreateGenreAsync(Genre genre);
        Task<List<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(Guid id);
        Task<bool> EditGenreAsync(Genre genre);
        Task<bool> DeleteGenreAsync(Guid actorId);
    }
}
