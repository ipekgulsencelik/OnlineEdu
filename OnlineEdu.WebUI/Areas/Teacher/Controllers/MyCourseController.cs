using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MyCourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public MyCourseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = await _client.GetFromJsonAsync<List<ResultCourseDTO>>("Courses/GetCoursesByTeacherID/" + user.Id);
            return View(values);
        }

        public async Task<IActionResult> CreateCourse()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDTO>>("courseCategories");

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CourseCategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDTO createCourseDTO)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            createCourseDTO.AppUserId = user.Id;
            createCourseDTO.IsShown = false;
            await _client.PostAsJsonAsync("Courses", createCourseDTO);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync("Courses/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCourse(int id)
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDTO>>("courseCategories");

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CourseCategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            var value = await _client.GetFromJsonAsync<UpdateCourseDTO>("Courses/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDTO updateCourseDTO)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            updateCourseDTO.AppUserId = user.Id;
            await _client.PutAsJsonAsync("Courses", updateCourseDTO);

            return RedirectToAction("Index");
        }
    }
}