using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Crossways.Models
{
    public class PhotoUploadModel
    {
        [Required(ErrorMessage = "Please choose profile image")]  
        [Display(Name = "Image")]  
        public IFormFile Image { get; set; }
    }
}