using BusinessLayer.Abstract.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities
{
    public class ImageManager : IImageService
    {
        public string SaveImage(IFormFile image, string imageFilesPath)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + imageFilesPath + "/", newImageName);
            using (var stream = new FileStream(location, FileMode.Create))
            {
                image.CopyTo(stream);
                return "/"+imageFilesPath + "/" + newImageName;
            }
        }
        public void DeleteImage(string imagePath)
        {
            if (!imagePath.Contains("nophoto"))
            {
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath);
                if (System.IO.File.Exists(location))
                { System.IO.File.Delete(location); }
            }

        }
    }
}
