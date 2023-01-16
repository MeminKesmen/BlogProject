using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.Utilities
{
    public interface IImageService
    {
        string SaveImage(IFormFile image, string imagePath);
        void DeleteImage(string imagePath);
    }
}
