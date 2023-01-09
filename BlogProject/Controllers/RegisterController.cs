using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class RegisterController : Controller
    {
        private IWriterService _writerService;
        private WriterValidator writerValidation;
        public RegisterController()
        {
            _writerService = new WriterManager(new EfWriterDal());
            writerValidation = new WriterValidator();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            var result = writerValidation.Validate(writer);
            if (result.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme";
                _writerService.Add(writer);
                return RedirectToAction("Index", "Blog ");

            }else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}
