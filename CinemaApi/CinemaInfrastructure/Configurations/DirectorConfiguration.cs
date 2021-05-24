using CinemaCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CinemaInfrastructure.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasMany(d => d.Movies)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId);
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasData
            (
                new Director
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Joss",
                    LastName = "Whedon",
                    DateOfBirth = new DateTime(1964, 6, 23)
                },
                new Director
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jon",
                    LastName = "Favreu",
                    DateOfBirth = new DateTime(1966, 10, 19)
                },
                new Director
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Terry",
                    LastName = "Gilliam",
                    DateOfBirth = new DateTime(1940, 11, 22)
                }
            );
        }
    }
}
