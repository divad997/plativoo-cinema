using CinemaCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CinemaInfrastructure.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasData
            (
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Horror"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Action"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Comedy"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Thriller"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Drama"
                }
            );
        }
    }
}
