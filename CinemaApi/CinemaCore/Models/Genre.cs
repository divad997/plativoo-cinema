using System;
using System.Collections.Generic;

namespace CinemaCore.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Genre(string name)
        {
            Name = name;
        }

        public Genre()
        {
        }

        public void Update(Genre genre)
        {
            Name = genre.Name;
        }
    }
}
