using CinemaApi.Interfaces;
using CinemaCore.Models;
using CinemaInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly CinemaDbContext _context;

        public DirectorService(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<Director> CreateDirectorAsync(Director director)
        {
            if (_context.Directors == null)
                throw new Exception("Couldn't retrieve the directors!");
            else
            {
                Director newDirector = new Director(director.FirstName, director.LastName, director.DateOfBirth);

                _context.Directors.Add(newDirector);
                await _context.SaveChangesAsync();

                return newDirector;
            }
        }

        public async Task<List<Director>> GetAllDirectorsAsync()
        {
            var directors = await _context.Directors
                .Include(d => d.Movies)
                .ToListAsync();

            if (directors == null)
                throw new Exception("Couldn't retrieve the directors!");
            else
                return directors;
        }

        public async Task<Director> GetDirectorByIdAsync(Guid id)
        {
            var director = await _context.Directors
                .Include(a => a.Movies)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (director == null)
                throw new Exception("Couldn't retrieve the director!");
            else
                return director;
        }

        public async Task<bool> EditDirectorAsync(Director director)
        {
            var editedDirector = await _context.Directors.FindAsync(director.Id);

            editedDirector.Update(director);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDirectorAsync(Guid directorId)
        {
            var director = await _context.Directors.FindAsync(directorId);

            if (director == null)
                throw new Exception("List with given id doesn't exist!");
            else
            {
                _context.Directors.Remove(director);
                return await _context.SaveChangesAsync() == 1;
            }
        }
    }
}
