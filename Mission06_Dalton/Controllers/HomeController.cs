using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Dalton.Models;

namespace Mission06_Dalton.Controllers;

public class HomeController : Controller
{
    private MoviesContext _context;
    public HomeController(MoviesContext movieBlank)
    {
        _context = movieBlank;
    }

    // Home page directions
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    // Get and post methods for adding form to the database
    [HttpGet]
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories.ToList();
        
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        _context.Movies.Add(movie); // Add the movie to the database for Joel's connection
        _context.SaveChanges(); // Makes permanant the addition to the DB
    
        // Redirect to the confirmation of adding the page
        return View("Confirmation", movie);
    }
    
    // For accessing the about page
    [HttpGet]
    public IActionResult About()
    {
        return View();
    }


    public IActionResult MovieList()
    {
        // Linq, using sql style to get the movie data from database
        var movies = _context.Movies
            .Where(x => x.Year == DateTime.Now.Year)
            .ToList();
        
        return View(movies);

    }
}