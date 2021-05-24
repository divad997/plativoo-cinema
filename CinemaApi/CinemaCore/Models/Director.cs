using System;
using System.Collections.Generic;

namespace CinemaCore.Models
{
    public class Director
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Director(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Director()
        {
        }

        public void Update(Director director)
        {
            FirstName = director.FirstName;
            LastName = director.LastName;
            DateOfBirth = director.DateOfBirth;
        }
    }
}
