using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterRoleController : Controller
    {
        private IWriterService _writerService;
        private IWriterRoleService _writerRoleService;
        private IRoleService _roleService;
        public WriterRoleController()
        {
            _writerService = new WriterManager(new EfWriterDal(), new EfBlogDal());
            _writerRoleService = new WriterRoleManager(new EfWriterRoleDal());
            _roleService = new RoleManager(new EfRoleDal());
        }
        public IActionResult Index(int page = 1)
        {
            var writerList = _writerService.GetAll().ToPagedList(page, 10);
            return View(writerList);
        }
        public IActionResult Role(int id)
        {
            var writer = _writerService.GetWriterWithRoles(w => w.WriterId == id);//null kontrol
            var inRoleList = writer.WriterRoles.Select(r => new SelectListItem { Text = r.Role.RoleName, Value = r.RoleId.ToString() }).ToList();
            inRoleList.Add(new SelectListItem { Text = "Silmek İçin Seçim Yapınız", Value = "0", Selected = true });

            ViewBag.InRole = inRoleList;
            List<SelectListItem> outRoleList = new List<SelectListItem>();
            outRoleList.Add(new SelectListItem { Text = "Eklemek İçin Seçim Yapınız", Value = "0", Selected = true });
            foreach (var roles in _roleService.GetAll())
            {
                if (!writer.WriterRoles.Any(r => r.RoleId == roles.RoleId))
                {
                    outRoleList.Add(new SelectListItem { Text = roles.RoleName, Value = roles.RoleId.ToString() });
                }
            }
            ViewBag.OutRole = outRoleList;
            return View(writer);
        }
        [HttpPost]
        public IActionResult Role(int id, int addRole, int deleteRole)
        {
            var writer = _writerService.GetWriterWithRoles(w => w.WriterId == id);//null kontrol
            if (addRole != 0 && !writer.WriterRoles.Any(r => r.Role.RoleId == addRole))
            {
                _writerRoleService.Add(new WriterRole { WriterId = writer.WriterId, RoleId = addRole });
                return RedirectToAction("Role", new { id = id });
            }
            if (deleteRole != 0 && writer.WriterRoles.Any(r => r.Role.RoleId == deleteRole))
            {
                var writerRole = _writerRoleService.Get(wr => wr.WriterId == id && wr.RoleId == deleteRole);
                _writerRoleService.Delete(writerRole);
                return RedirectToAction("Role", new { id = id });
            }
            return RedirectToAction("Index");
        }
    }
}
