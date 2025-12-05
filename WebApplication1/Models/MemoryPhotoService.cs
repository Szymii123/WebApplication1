using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public class MemoryPhotoService : IPhotoService
    {
        private readonly Dictionary<int, Photo> _items = new();
        private int _id = 0;

        public void AddPhoto(Photo photo)
        {
            photo.Id = ++_id;
            _items.Add(photo.Id, photo);
        }

        public bool DeletePhotoById(int id)
        {
            return _items.Remove(id);
        }

        public List<Photo> GetPhotos()
        {
            return _items.Values.ToList();
        }

        public Photo? GetPhotoById(int id)
        {
            return _items.TryGetValue(id, out var photo) ? photo : null;
        }

        public bool UpdatePhoto(Photo photo)
        {
            if (!_items.ContainsKey(photo.Id))
                return false;

            _items[photo.Id] = photo;
            return true;
        }
    }
}