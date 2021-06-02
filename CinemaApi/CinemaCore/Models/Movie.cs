using System;
using System.Collections.Generic;

namespace CinemaCore.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = new Genre();
        public Guid DirectorId { get; set; }
        public Director Director { get; set; } = new Director();
        public List<Actor> Actors { get; set; } = new List<Actor>();

        public Movie(string name, DateTime releaseDate)
        {
            Name = name;
            ReleaseDate = releaseDate;
        }

        public Movie(Movie movie)
        {
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            DirectorId = movie.DirectorId;
        }

        public Movie()
        { 
        }
    }
}
