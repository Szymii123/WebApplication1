using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


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

        [Display(Name = "Album")]
        [HiddenInput]
        public int AlbumId { get; set; }


        [ValidateNever]
        public List<SelectListItem> Albums { get; set; }
    }
}