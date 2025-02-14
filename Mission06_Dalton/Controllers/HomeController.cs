using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Dalton.Models;

namespace Mission06_Dalton.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        return View("Confirmation", movie);
    }
    
    // For accessing the about page
    [HttpGet]
    public IActionResult About()
    {
        return View();
    }
    
}