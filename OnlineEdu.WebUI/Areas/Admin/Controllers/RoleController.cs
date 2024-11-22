using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.RoleDTOs;
using OnlineEdu.WebUI.Services.RoleServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class RoleController(IRoleService _roleService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _roleService.GetAllRolesAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDTO createRoleDTO)
        {
            await _roleService.CreateRoleAsync(createRoleDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return RedirectToAction("Index");
        }
    }
}