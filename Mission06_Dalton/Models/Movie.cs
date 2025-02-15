using System.ComponentModel.DataAnnotations;

namespace Mission06_Dalton.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieID { get; set; }
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    [Range(1900, 2100)]
    public int Year { get; set; }
    
    [Required]
    public string Director { get; set; }
    
    [Required]
    public string Rating { get; set; }
    
    public bool Edited { get; set; } = false;
    public string LentTo { get; set; } = "None";
    
    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string Notes { get; set; } = string.Empty;
    
}