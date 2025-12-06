using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            var photos = _photoService.GetPhotos();
            return View(photos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Photo model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _photoService.AddPhoto(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var photo = _photoService.GetPhotoById(id);
            if (photo == null)
                return NotFound();

            return View(photo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var photo = _photoService.GetPhotoById(id);
            if (photo == null)
                return NotFound();

            return View(photo);
        }

        [HttpPost]
        public IActionResult Edit(Photo model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _photoService.UpdatePhoto(model);
            return RedirectToAction(nameof(Index));


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var photo = _photoService.GetPhotoById(id);
            if (photo == null)
                return NotFound();

            return View(photo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _photoService.DeletePhotoById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}