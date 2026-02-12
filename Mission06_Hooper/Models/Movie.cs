using System;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Hooper.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Category { get; set; }  // Changed from CategoryId to text field

        [Required]
        public int RatingId { get; set; }      // Keep this for the dropdown

        public bool? Edited { get; set; }      // ✅ Has ?
        public string? LentTo { get; set; }     // ✅ Has ?
        public string? Notes { get; set; }      // ✅ Has ?

        // Navigation property - keep this for Rating
        public Rating Rating { get; set; }
    }
}