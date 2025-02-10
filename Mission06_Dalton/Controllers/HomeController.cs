using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Dalton.Models;

namespace Mission06_Dalton.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


}