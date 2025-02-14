namespace Mission06_Dalton.Models;

public class Movie
{
    public int MovieID { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public string Rating { get; set; }
    public bool Edited { get; set; } = false;
    public string LentTo { get; set; }
    public string Notes { get; set; }
    
}