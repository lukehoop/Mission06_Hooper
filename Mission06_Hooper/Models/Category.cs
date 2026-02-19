using System.ComponentModel.DataAnnotations;

namespace Mission06_Hooper.Models
{
    // Category lookup table - matches database Categories table
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Navigation property - one category has many movies
        public ICollection<Movie>? Movies { get; set; }
    }
}