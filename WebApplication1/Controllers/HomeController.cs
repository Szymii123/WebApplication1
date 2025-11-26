using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }


    // w op może wystąpić: add, sub, mul, div
    public IActionResult Calculator(double? a, double? b, [FromQuery(Name = "operator")] string op)
    {
        
        ViewBag.A = a;
        ViewBag.B = b;
        ViewBag.Op = op;
        
        if (a is null || b is null)
        {
            ViewBag.Error = "Brak parametru a lub b!";
            return View("Calculator");
        }

        double result;

        switch (op)
        {
            case "add":
                result = a.Value + b.Value;
                break;
            case "sub":
                result = a.Value - b.Value;
                break;
            case "mul":
                result = a.Value * b.Value;
                break;
            case "div":
                result = a.Value / b.Value;
                break;
            default:
                ViewBag.Error = "Nieznany operator!";
                return View("Calculator");
        }

        ViewBag.Result = result;
        return View("Calculator");
    }

    
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}