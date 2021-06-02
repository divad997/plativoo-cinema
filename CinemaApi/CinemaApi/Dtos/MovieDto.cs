using System;
using System.Collections.Generic;

namespace CinemaApi.Dtos
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid GenreId { get; set; }
        public Guid DirectorId { get; set; }
        public List<Guid> ActorIds { get; set; }
    }
}
