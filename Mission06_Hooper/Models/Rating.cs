using System.ComponentModel.DataAnnotations;

namespace Mission06_Hooper.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        public string RatingName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}