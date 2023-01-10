using BlogProject.Models.ViewModels;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class WriterController : Controller
    {
        private IWriterService _writerService;
        private WriterValidator writerValidation;
        public WriterController()
        {
            _writerService = new WriterManager(new EfWriterDal());
            writerValidation = new WriterValidator();
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult WriterSideBarPartial()
        {
            return PartialView();
        }
        public IActionResult WriterEditProfile()
        {
            var writer = _writerService.Get(w=>w.WriterId==1);

            return View(writer);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {

            ValidationResult result = writerValidation.Validate(writer);
            if (result.IsValid) 
            {
                _writerService.Update(writer);//null ve id kontrol
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                
            }

            return View(writer);
        }
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(WriterProfile writerProfile)
        {
            Writer writer = new Writer();
            if (writerProfile.WriterImage!=null) 
            {
                var extension = Path.GetExtension(writerProfile.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "www/root/WriterImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writerProfile.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;

            }
            writer.WriterMail = writerProfile.WriterMail;
            writer.WriterName = writerProfile.WriterName;
            writer.WriterPassword = writerProfile.WriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = writerProfile.WriterAbout;
            _writerService.Add(writer);
            return RedirectToAction("Index","DashBoard");
        }
    }
}
