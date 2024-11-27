using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDTO>>("CourseCategories");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync("CourseCategories/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDTO createCourseCategoryDTO)
        {
            await _client.PostAsJsonAsync("CourseCategories", createCourseCategoryDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateCourseCategoryDTO>("CourseCategories/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDTO updateCourseCategoryDTO)
        {
            await _client.PutAsJsonAsync("CourseCategories", updateCourseCategoryDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}