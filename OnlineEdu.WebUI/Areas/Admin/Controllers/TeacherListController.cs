using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TeacherListController : Controller
    {
        private readonly HttpClient _client;

        public TeacherListController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _client.GetFromJsonAsync<List<ResultUserDTO>>("Users/TeacherList");
            return View(teachers);
        }

        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(UserRegisterDTO userRegisterDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterDTO);
            }

            var response = await _client.PostAsJsonAsync("Users/CreateTeacher", userRegisterDTO);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(userRegisterDTO);
        }

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _client.DeleteAsync("Users/" + id);
            return RedirectToAction("Index");
        }
    }
}