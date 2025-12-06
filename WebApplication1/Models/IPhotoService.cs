using System.Collections.Generic;

namespace WebApplication1.Models
{
    public interface IPhotoService
    {
        List<Photo> GetPhotos();
        Photo? GetPhotoById(int id);
        int AddPhoto(Photo photo);
        void UpdatePhoto(Photo photo);
        void DeletePhotoById(int id);
    }
}