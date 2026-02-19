using System;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Hooper.Models
{
    // Movie model - matches database structure with nullable fields for existing data
    public class Movie
    {
        // Primary key
        [Key]
        public int MovieId { get; set; }

        // Make nullable to handle existing database records with NULL values
        public string? Title { get; set; }

        // Year nullable - some records don't have years
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        // Foreign key to Categories table - nullable
        public int? CategoryId { get; set; }

        // Rating stored as text - nullable
        public string? Rating { get; set; }

        // Edited - nullable in existing data
        public bool? Edited { get; set; }

        // CopiedToPlex - nullable in existing data
        public bool? CopiedToPlex { get; set; }

        // Optional fields
        public string? LentTo { get; set; }
        public string? Notes { get; set; }

        // Navigation property to Category - nullable
        public Category? Category { get; set; }
    }
}