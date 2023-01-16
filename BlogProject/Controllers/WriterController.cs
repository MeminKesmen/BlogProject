using BlogProject.Generic;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Utilities;
using BusinessLayer.Concrete;
using BusinessLayer.Utilities;
using BusinessLayer.ValidationRules.FluentValidation;
using BusinessLayer.ViewModels;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [Authorize(Roles = "Writer")]
    public class WriterController : MyController
    {
        private IWriterService _writerService;
        private IImageService _imageService;

        public WriterController(IWriterService writerService, IImageService imageService)
        {
            _writerService = writerService;
            _imageService = imageService;

        }
        public IActionResult WriterEditProfile()
        {
            var user = GetCurrentUser();
            var writer = _writerService.Get(w => w.WriterId == user.UserId);
            var editWriter = new WriterProfile
            {
                WriterName = writer.WriterName,
                WriterMail = writer.WriterMail,
                WriterPassword = writer.WriterPassword,
                WriterAbout = writer.WriterAbout,
            };


            return View(editWriter);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(WriterProfile writerProfile)
        {
            var user = GetCurrentUser();
            var writer = _writerService.Get(w => w.WriterId == user.UserId);

            if (!ModelState.IsValid) { return View(writer); }
            if (writerProfile.WriterImage != null)
            {
                _imageService.DeleteImage(writer.WriterImage);
                writer.WriterImage = _imageService.SaveImage(writerProfile.WriterImage, "WriterImages");
            }
            writer.WriterMail = writerProfile.WriterMail;
            writer.WriterName = writerProfile.WriterName;
            writer.WriterPassword = writerProfile.WriterPassword;
            writer.WriterAbout = writerProfile.WriterAbout;
            _writerService.Update(writer);
            return RedirectToAction("WriterEditProfile");
        }

    }
}
