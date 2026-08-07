using Microsoft.EntityFrameworkCore;

namespace UrlShortener.API.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<UrlMapping> Mapping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlMapping>()
                .HasIndex(u => u.Code)
                .IsUnique();

            modelBuilder.Entity<UrlMapping>()
                .HasIndex(u => u.LongUrl);
        }
    }
}
