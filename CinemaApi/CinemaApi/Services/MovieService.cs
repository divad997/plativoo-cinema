using AutoMapper;
using CinemaApi.Dtos;
using CinemaApi.Interfaces;
using CinemaCore.Models;
using CinemaInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public MovieService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Movie> CreateMovieAsync(MovieDto movieDto)
        {
            if (_context.Movies == null)
                throw new Exception("Couldn't retrieve the movies!");
            else
            {
                var newMovie = new Movie();
                _mapper.Map(movieDto, newMovie);

                foreach (Guid id in movieDto.ActorIds)
                {
                    newMovie.Actors.Add(await _context.Actors.FirstOrDefaultAsync(a => a.Id == id));
                }

                newMovie.Director = await _context.Directors.FirstOrDefaultAsync(d => d.Id == movieDto.DirectorId);
                newMovie.Genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == movieDto.GenreId);

                await _context.Movies.AddAsync(newMovie);

                await _context.SaveChangesAsync();

                return newMovie;
            }
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies
                .Include(m => m.Actors)
                //.Include(m => m.Director)
                //.Include(m => m.Genre)
                .ToListAsync();

            foreach (Movie mov in movies)
            {
                mov.Genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == mov.GenreId);
                mov.Director = await _context.Directors.FirstOrDefaultAsync(d => d.Id == mov.DirectorId);
            }

            if (movies == null)
                throw new Exception("Couldn't retrieve the movies!");
            else
                return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            var movie = await _context.Movies
                .Include(m => m.Actors)
                //.Include(m => m.Director)
               // .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);

            movie.Genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == movie.GenreId);
            movie.Director = await _context.Directors.FirstOrDefaultAsync(d => d.Id == movie.DirectorId);

            if (movie == null)
                throw new Exception("Couldn't retrieve the movie!");
            else
                return movie;
        }
   
        public async Task<bool> EditMovieAsync(MovieDto movieDto)
        {
            var editedMovie = await _context.Movies
                .Include(m => m.Actors)
                .Include(m => m.Director)
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == movieDto.Id);

            editedMovie.Actors = new List<Actor>();
            foreach (Guid id in movieDto.ActorIds)
            {
                editedMovie.Actors.Add(await _context.Actors.FirstOrDefaultAsync(a => a.Id == id));
            }

            editedMovie.Director = await _context.Directors.FirstOrDefaultAsync(d => d.Id == movieDto.DirectorId);
            editedMovie.Genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == movieDto.GenreId);

            editedMovie.Name = movieDto.Name;
            editedMovie.ReleaseDate = movieDto.ReleaseDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovieAsync(Guid movieId)
        {
            var movie  = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
                throw new Exception("List with given id doesn't exist!");
            else
            {
                _context.Movies.Remove(movie);
                return await _context.SaveChangesAsync() == 1;
            }
        }             
    }
}
