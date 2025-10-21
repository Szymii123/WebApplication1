using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class PhotoController : Controller
{
    private static Dictionary<int, Photo> photos = new();

    private static  int i = 0;
    // GET
    public IActionResult Index()
    {
        return View(photos.Values.ToList());
    }

    [HttpGet] // wyświetlanie formularza dodania obiektu
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] 
    public IActionResult Create(Photo model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = ++i;
        photos.Add(model.Id, model);
          return  RedirectToAction("Index");
       
            
    }
}