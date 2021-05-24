using CinemaApi.Interfaces;
using CinemaCore.Models;
using CinemaInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class GenreService : IGenreService
    {
        private readonly CinemaDbContext _context;

        public GenreService(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            if (_context.Genres == null)
                throw new Exception("Couldn't retrieve the genres!");
            else
            {
                Genre newGenre = new Genre(genre.Name);

                _context.Genres.Add(newGenre);
                await _context.SaveChangesAsync();

                return newGenre;
            }
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            var genres = await _context.Genres
                .Include(a => a.Movies)
                .ToListAsync();

            if (genres == null)
                throw new Exception("Couldn't retrieve the genres!");
            else
                return genres;
        }

        public async Task<Genre> GetGenreByIdAsync(Guid id)
        {
            var genre = await _context.Genres
                .Include(g => g.Movies)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (genre == null)
                throw new Exception("Couldn't retrieve the genre!");
            else
                return genre;
        }

        public async Task<bool> EditGenreAsync(Genre genre)
        {
            var editedGenre = await _context.Genres.FindAsync(genre.Id);

            editedGenre.Update(genre);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGenreAsync(Guid genreId)
        {
            var genre = await _context.Genres.FindAsync(genreId);

            if (genre == null)
                throw new Exception("Genre with given id doesn't exist!");
            else
            {
                _context.Genres.Remove(genre);
                return await _context.SaveChangesAsync() == 1;
            }
        }
    }
}
