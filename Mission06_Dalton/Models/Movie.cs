using System.ComponentModel.DataAnnotations;

namespace Mission06_Dalton.Models;

public class Movie
{
    public int MovieID { get; set; }
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public string Director { get; set; }
    
    [Required]
    public string Rating { get; set; }
    
    public bool Edited { get; set; } = false;
    public string LentTo { get; set; } = string.Empty;
    
    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string Notes { get; set; } = string.Empty;
    
}