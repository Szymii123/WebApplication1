using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PhotoController : Controller
    {
        private static Dictionary<int, Photo> photos = new();
        
        private static int nextId = 1;
        
        public IActionResult Index()
        {
            return View(photos.Values.ToList());
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Photo model)
        {
            ModelState.Remove(nameof(Photo.Id));

            if (ModelState.IsValid)
            {
               
                model.Id = nextId++;
                
                photos.Add(model.Id, model);
                
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (photos.TryGetValue(id, out var photo))
            {
                return View(photo);
            }

            return NotFound();
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (photos.TryGetValue(id, out var photo))
            {
                return View(photo);
            }

            return NotFound();
        }
        
        [HttpPost]
        public IActionResult Edit(int id, Photo model)
        {
            ModelState.Remove(nameof(Photo.Id));

            if (ModelState.IsValid)
            {
                if (photos.ContainsKey(id))
                {
                    model.Id = id;
                    
                    photos[id] = model;

                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (photos.TryGetValue(id, out var photo))
            {
                return View(photo);
            }

            return NotFound();
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (photos.ContainsKey(id))
            {
                photos.Remove(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
