using System;
using System.IO;
using Crossways.Models;
using Microsoft.AspNetCore.Hosting;

namespace Crossways.Services
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHost;

        public FileUploader(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        } 

        public string ImageUploader(PhotoUploadModel model)  
        {  
            string uniqueFileName = null;  
  
            if (model.Image != null)  
            {  
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "uploads");  
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;  
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);  
                using (var fileStream = new FileStream(filePath, FileMode.Create))  
                {  
                    model.Image.CopyTo(fileStream);  
                }  
            }

            return uniqueFileName;  
        } 
    }
}