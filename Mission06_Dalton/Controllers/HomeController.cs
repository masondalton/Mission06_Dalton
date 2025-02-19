using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        var movies = _context.Movies.Include(m => m.Category).ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var record = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories.ToList();
        return View("AddMovie", record);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        _context.Update(movie);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var record = _context.Movies.Single(x => x.MovieId == id);
        
        return View(record);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }
}