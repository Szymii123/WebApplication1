using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        
        private void InitAlbums(Photo model)
        {
            model.Albums = _photoService
                .FindAllAlbums()
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Title
                })
                .ToList();
        }
        
        public IActionResult Index()
        {
            var photos = _photoService.GetPhotos();
            return View(photos);
        }
        
        public IActionResult Details(int id)
        {
            var photo = _photoService.GetPhotoById(id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }
        
        public IActionResult Create()
        {
            var model = new Photo
            {
                DateTaken = DateTime.Now
            };

            InitAlbums(model);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Photo model)
        {
            if (!ModelState.IsValid)
            {
                InitAlbums(model);
                return View(model);
            }

            _photoService.AddPhoto(model);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Edit(int id)
        {
            var photo = _photoService.GetPhotoById(id);
            if (photo == null)
            {
                return NotFound();
            }

            InitAlbums(photo);
            return View(photo);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Photo model)
        {
            if (!ModelState.IsValid)
            {
                InitAlbums(model);
                return View(model);
            }

            _photoService.UpdatePhoto(model);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete(int id)
        {
            var photo = _photoService.GetPhotoById(id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _photoService.DeletePhotoById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
