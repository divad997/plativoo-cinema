using CinemaCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaInfrastructure.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                .HasDefaultValueSql("NEWID()");          
        }
    }
}
