using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Form()
    {
        return View();
    }
    
    public IActionResult Result(CalculatorModel model)
    {
        
       if ( !model.IsValid())
       {
          return View("Error", model:"Nie można obliczyć");
       }
       
        ViewBag.Result = model.Result();
        return View();
    }
    
}