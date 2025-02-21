using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Dalton.Models;

namespace Mission06_Dalton.Controllers;

public class HomeController : Controller
{
    // _context is the liason to the database we will use for referencing the tables
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
        ViewBag.Categories = _context.Categories.OrderBy(m => m.CategoryName).ToList();
        
        return View("AddMovie", new Movie());
    }
    
    // For sending new movie to database
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        { 
            _context.Movies.Add(movie); // Add the movie to the database for Joel's connection
            _context.SaveChanges(); // Makes permanant the addition to the DB
                
            // Redirect to the confirmation of adding the page
            return View("Confirmation", movie);
        }
        else
        {
            ViewBag.Categories = _context.Categories.OrderBy(m => m.CategoryName).ToList();
            return View(movie);
        }
       
    }
    
    // For accessing the about page
    [HttpGet]
    public IActionResult About()
    {
        return View();
    }
    
    // For displaying a table with a list of all the movies and their categories
    public IActionResult MovieList()
    {
        // Linq, using sql style to get the movie data from database
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title).ToList();
        return View(movies);
    }

    // For opening the edit page and filling in the values based on what movie was chosen to be edited. 
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var record = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories.ToList();
        return View("AddMovie", record);
    }

    // Specific to editing, sends update to the database with changes
    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        _context.Update(movie);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

    // Opens up a page to confirm user want's to delete the movie record
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var record = _context.Movies.Single(x => x.MovieId == id);
        
        return View(record);
    }

    // After confirmation, delete the selected movie
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }
}