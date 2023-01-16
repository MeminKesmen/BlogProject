using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Writer")]
    public class WriterController : Controller
    {
        private IWriterService _writerService;
        public WriterController()
        {
            _writerService = new WriterManager(new EfWriterDal(), new EfBlogDal());
        }
        public IActionResult Index(int page = 1)
        {
            var writerList = _writerService.GetAllWriterWithBlogCount().ToPagedList(page, 10);
            return View(writerList);
        }
        public IActionResult WriterDelete(int id)
        {
            var writer = _writerService.Get(w => w.WriterId == id);//null kontrol
            if (writer != null) { _writerService.Delete(writer); }

            return RedirectToAction("Index");
        }
    }
}
