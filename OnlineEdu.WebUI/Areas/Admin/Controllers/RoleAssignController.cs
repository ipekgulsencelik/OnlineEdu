using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.RoleDTOs;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Models;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleAssignController : Controller
    {
        private readonly HttpClient _client;
        private readonly IUserService _userService;

        public RoleAssignController(IHttpClientFactory clientFactory, IUserService userService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetAllUsersAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var values = await _userService.GetUserForRoleAssign(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDTO> assignRoleList)
        {
            var result = await _client.PostAsJsonAsync("RoleAssigns", assignRoleList);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(assignRoleList);
        }

        public async Task<IActionResult> CreateUser()
        {
            var roles = await _client.GetFromJsonAsync<List<ResultRoleDTO>>("Roles");
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
            if (!ModelState.IsValid)
            {
                return View(createUserViewModel);
            }

            if (createUserViewModel.Password != createUserViewModel.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Şifreler birbirini tutmuyor.");
                return View(createUserViewModel);
            }

            var newUser = new UserRegisterDTO()
            {
                FirstName = createUserViewModel.FirstName,
                LastName = createUserViewModel.LastName,
                UserName = createUserViewModel.UserName,
                Email = createUserViewModel.Email,
                Password = createUserViewModel.Password,
                ConfirmPassword = createUserViewModel.ConfirmPassword
            };

            var response = await _client.PostAsJsonAsync("Users/Register", newUser);

            if (!response.IsSuccessStatusCode)
            {
                return View(createUserViewModel);
            }

            var assignRolesResponse = await _client.PostAsJsonAsync("RoleAssigns", createUserViewModel.Roles);

            if (!assignRolesResponse.IsSuccessStatusCode)
            {
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