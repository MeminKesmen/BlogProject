using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterSiderbarProfile : ViewComponent
    {
        private IWriterService _writerService;
        public WriterSiderbarProfile()
        {
            _writerService = new WriterManager(new EfWriterDal(),new EfBlogDal());
        }
        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var id = userId == null ? 1 : int.Parse(userId);
            var writer = _writerService.GetWriterWithRoles(w=>w.WriterId==id);
            return View(writer);
        }
    }
}
