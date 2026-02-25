using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08.Models;

namespace Mission08.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    
}