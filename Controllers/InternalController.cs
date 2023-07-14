using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RyewoodResidents.Models;

namespace RyewoodResidents.Controllers;

public class InternalController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public InternalController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Parking()
    {
        return View();
    }

    public IActionResult Flats()
    {
        return View();
    }
    public IActionResult Gym()
    {
        return View();
    }
    public IActionResult Rubbish()
    {
        return View();
    }
}