using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models;

public class Photo
{
    [HiddenInput] public int Id { get; set; }

   [DataType(DataType.Date)]
    public DateTime Data { get; set; }


    public TimeOnly Hour { get; set; }

    [StringLength(maximumLength: 500, MinimumLength = 2)]
    public string Description { get; set; }


    public string Camera { get; set; }


    public string Author { get; set; }


    public string Resolution { get; set; }


    public string Format { get; set; }
}