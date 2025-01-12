using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TeacherListController(UserManager<AppUser> _userManager, IUserService _userService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            return View(teachers);
        }

        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(UserRegisterDTO userRegisterDTO)
        {
            var result = await _userService.CreateTeacherUserAsync(userRegisterDTO);
            if (!result.Succeeded || !ModelState.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}