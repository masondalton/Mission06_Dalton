using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Dalton.Models;

// this model is for each movie. It requires certain data (Title, year, if it was edited, or if was copied to plex)
// and includes custom error messages. Make sure the fk relationship is set up between movie and category. 
public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; } // Created by model
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; } // Nullable, if no connection to movie
    public Category? Category { get; set; } // Nullable, if no connection to movie
    
    [Required(ErrorMessage = "You must enter a title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "You must enter a year")]
    [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100")] // No movies were made before 1888
    public int Year { get; set; } = 0;

    public string? Director { get; set; } // Nullable
    
    public string? Rating { get; set; } // Nullable
    
    [Required(ErrorMessage = "You must enter edited status")]
    public bool Edited { get; set; }
    
    public string? LentTo { get; set; } // Nullable
    
    [Required(ErrorMessage = "You must enter if it was copied to plex")]
    public bool CopiedToPlex { get; set; }
    
    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; } // Nullable
    
}