using System.Collections.Generic;

namespace WebApplication1.Models
{
    public interface IPhotoService
    {
        void AddPhoto(Photo photo);
        bool DeletePhotoById(int id);
        bool UpdatePhoto(Photo photo);
        List<Photo> GetPhotos();
        Photo? GetPhotoById(int id);
    }
}