using CinemaCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Interfaces
{
    public interface IMovieService
    {      
        Task<Movie> CreateMovieAsync(Movie movie);
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<bool> EditMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(Guid actorId);
    }
}
