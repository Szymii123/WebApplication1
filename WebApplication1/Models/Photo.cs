using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Display(Name = "Data i godzina")]
        [DataType(DataType.DateTime)]
        public DateTime DateTaken { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        [Display(Name = "Aparat")]
        public string? Camera { get; set; }

        [Display(Name = "Autor")]
        public string? Author { get; set; }

        [Display(Name = "Rozdzielczość")]
        public string? Resolution { get; set; }

        [Display(Name = "Format")]
        public PhotoFormat Format { get; set; }
    }
}