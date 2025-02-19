using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Dalton.Models;

// Movie class to be created when the form is filled out. Makes sure that users enter data for the required options 
// Include automatic false for edited, null optionals for lent status or any notes
public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public string Title { get; set; }

    public int Year { get; set; }

    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    
    public bool Edited { get; set; } = false;
    
    public string? LentTo { get; set; }
    
    public bool CopiedToPlex { get; set; } = false;
    
    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
    
}