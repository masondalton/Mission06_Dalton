using Microsoft.EntityFrameworkCore;

namespace Mission06_Dalton.Models;

// Conext file for getting movies into the database
public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) { }
    
    public DbSet<Movie> Movies { get; set; }
}