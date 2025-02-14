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

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddMovie()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
}