using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Form()
    {
        return View();
    }
    
    public IActionResult Result(Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }

        return View(model);
    }
}