using System;
using System.Collections.Generic;

namespace CinemaCore.Models
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Actor(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Actor()
        {
        }
        public void Update(Actor actor)
        {
            FirstName = actor.FirstName;
            LastName = actor.LastName;
            DateOfBirth = actor.DateOfBirth;
        }
    }
}
