using Microsoft.EntityFrameworkCore;

namespace Mission06_Dalton.Models;

// Conext file for getting movies into the database
public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) { }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    // This is for seeding data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Informationi Systems" }
        );
    }
}