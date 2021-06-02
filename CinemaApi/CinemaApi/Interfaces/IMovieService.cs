using CinemaApi.Dtos;
using CinemaCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Interfaces
{
    public interface IMovieService
    {      
        Task<Movie> CreateMovieAsync(MovieDto movieDto);
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<bool> EditMovieAsync(MovieDto movieDto);
        Task<bool> DeleteMovieAsync(Guid movieId);
    }
}
