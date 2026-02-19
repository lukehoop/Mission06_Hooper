using Microsoft.EntityFrameworkCore;

namespace Mission06_Hooper.Models
{
    // Database context - configures EF Core for SQLite
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        // DbSets - represent database tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }

        // No seed data needed - database already exists with data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Empty - Joel's data is already in the database file
        }
    }
}