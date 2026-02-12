using Microsoft.EntityFrameworkCore;

namespace Mission06_Hooper.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }


        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rating>().HasData(
                new Rating { RatingId = 1, RatingName = "G" },
                new Rating { RatingId = 2, RatingName = "PG" },
                new Rating { RatingId = 3, RatingName = "PG-13" },
                new Rating { RatingId = 4, RatingName = "R" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "The Shawshank Redemption",
                    Year = 1994,
                    Director = "Frank Darabont",
                    Category = "Drama",     
                    RatingId = 4,
                    Edited = false,
                    LentTo = null,
                    Notes = "Best movie ever!"
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Category = "Sci-Fi",
                    RatingId = 3,
                    Edited = false,
                    LentTo = "John",
                    Notes = "Mind bending"
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Category = "Action",
                    RatingId = 3,
                    Edited = false,
                    LentTo = null,
                    Notes = "Best superhero film"
                }
            );
        }
    }
}