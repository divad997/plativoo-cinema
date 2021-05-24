using CinemaCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CinemaInfrastructure.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasData
            (
                new Actor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Robert",
                    LastName = "Downey Jr",
                    DateOfBirth = new DateTime(1965, 4, 4)
                },
                new Actor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Chris",
                    LastName = "Evans",
                    DateOfBirth = new DateTime(1981, 6, 13)
                },
                new Actor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mark",
                    LastName = "Ruffalo",
                    DateOfBirth = new DateTime(1967, 11, 22)
                },
                new Actor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Gwyneth",
                    LastName = "Paltrow",
                    DateOfBirth = new DateTime(1972, 8, 27)
                },
                new Actor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Johnny",
                    LastName = "Depp",
                    DateOfBirth = new DateTime(1963, 6, 9)
                },
                new Actor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Benicio",
                    LastName = "Del Toro",
                    DateOfBirth = new DateTime(1967, 2, 19)
                },
                new Actor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Tobey",
                    LastName = "Maguire",
                    DateOfBirth = new DateTime(1975, 6, 27)
                }

            );
        }
    }
}
