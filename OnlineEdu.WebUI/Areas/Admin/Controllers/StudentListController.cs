using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class StudentListController : Controller
    {
        private readonly HttpClient _client;

        public StudentListController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> Index()
        {
            var students = await _client.GetFromJsonAsync<List<ResultUserDTO>>("Users/StudentList");
            return View(students);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(UserRegisterDTO userRegisterDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterDTO);
            }

            var response = await _client.PostAsJsonAsync("Users/Register", userRegisterDTO);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(userRegisterDTO);
        }

        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _client.DeleteAsync("Users/" + id);
            return RedirectToAction("Index");
        }
    }
}