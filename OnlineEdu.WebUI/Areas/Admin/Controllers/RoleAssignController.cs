using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Models;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleAssignController(IUserService _userService, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetAllUsersAsync();
            var userList = (from user in values
                            select new UserViewModel
                            {
                                Id = user.Id,
                                NameSurname = user.FirstName + " " + user.LastName,
                                UserName = user.UserName,
                                Roles = _userManager.GetRolesAsync(user).Result.ToList(),
                            }).ToList();
            return View(userList);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            TempData["userId"] = user.Id;

            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<AssignRoleDTO> assignRoleList = new List<AssignRoleDTO>();

            foreach (var role in roles)
            {
                var assignRole = new AssignRoleDTO();

                assignRole.RoleId = role.Id;
                assignRole.RoleName = role.Name;
                assignRole.RoleExist = userRoles.Contains(role.Name);

                assignRoleList.Add(assignRole);
            }
            return View(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDTO> assignRoleList)
        {
            int userId = (int)TempData["userId"];

            var user = await _userService.GetUserByIdAsync(userId);

            foreach (var item in assignRoleList)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateUser()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var model = new CreateUserViewModel
            {
                Roles = roles.Select(role => new AssignRoleDTO
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    RoleExist = false
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel createUserViewModel)
        {
            if (createUserViewModel.Password != createUserViewModel.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Şifreler birbirini tutmuyor.");
                return View(createUserViewModel);
            }

            var newUser = new AppUser()
            {
                FirstName = createUserViewModel.FirstName,
                LastName = createUserViewModel.LastName,
                UserName = createUserViewModel.UserName,
                Email = createUserViewModel.Email
            };

            var result = await _userManager.CreateAsync(newUser, createUserViewModel.Password);

            if (result.Succeeded)
            {
                foreach (var item in createUserViewModel.Roles)
                {
                    if (item.RoleExist)
                    {
                        await _userManager.AddToRoleAsync(newUser, item.RoleName);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(newUser, item.RoleName);
                    }
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(createUserViewModel);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}