using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Photo
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj datę wykonania zdjęcia")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Podaj godzinę wykonania zdjęcia")]
        [DataType(DataType.Time)]
        public TimeOnly Hour { get; set; }

        [Required(ErrorMessage = "Podaj opis zdjęcia")]
        [StringLength(500, MinimumLength = 2,
            ErrorMessage = "Opis musi mieć od 2 do 500 znaków")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Podaj użyty aparat / kamerę")]
        public string Camera { get; set; }

        [Required(ErrorMessage = "Podaj autora zdjęcia")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Podaj rozdzielczość, np. 1920x1080")]
        [RegularExpression(@"^\d{3,5}x\d{3,5}$",
            ErrorMessage = "Podaj rozdzielczość w formacie np. 1920x1080")]
        public string Resolution { get; set; }

        [Required(ErrorMessage = "Podaj format pliku (np. jpg, png)")]
        [RegularExpression(@"^(jpg|jpeg|png|gif|bmp|tiff|webp)$",
            ErrorMessage = "Dopuszczalne formaty: jpg, jpeg, png, gif, bmp, tiff, webp")]
        public string Format { get; set; }
    }
}