using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public enum PhotoFormat
    {
        [Display(Name = "JPEG")] Jpeg = 1,
        [Display(Name = "PNG")] Png = 2,
        [Display(Name = "RAW")] Raw = 3,
        [Display(Name = "Inny")] Other = 4
    }
}