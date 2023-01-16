using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        public RoleController()
        {
            _roleService = new RoleManager(new EfRoleDal());
        }
        public IActionResult Index()
        {
            var roleList = _roleService.GetAll();
            return View(roleList);
        }
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RoleAdd(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return View(); }
            _roleService.Add(new Role { RoleName = name });
            return View();
        }
        public IActionResult RoleDelete(int id)
        {
            var role = _roleService.Get(r => r.RoleId == id);
            if (role != null) { _roleService.Delete(role); }

            return RedirectToAction("Index");
        }
        public IActionResult RoleEdit(int id)
        {
            var role = _roleService.Get(r => r.RoleId == id);//null kontrol
            if (role == null) { return RedirectToAction("Index"); }
            return View(role);
        }
        [HttpPost]
        public IActionResult RoleEdit(Role role)
        {
            if (string.IsNullOrWhiteSpace(role.RoleName)) { return View(role); }
            var findRole = _roleService.Get(r => r.RoleId == role.RoleId);
            if (findRole != null)
            {
                findRole.RoleName = role.RoleName;
                _roleService.Update(findRole);
            }

            return RedirectToAction("Index");
        }
    }
}
