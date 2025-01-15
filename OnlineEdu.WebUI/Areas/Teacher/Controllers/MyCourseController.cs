using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.DTOs.CourseVideoDTOs;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MyCourseController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public MyCourseController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;

            var values = await _client.GetFromJsonAsync<List<ResultCourseDTO>>("Courses/GetCoursesByTeacherID/" + userId);
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
            var userId = _tokenService.GetUserId;

            createCourseDTO.AppUserId = userId;
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
            var userId = _tokenService.GetUserId;
            updateCourseDTO.AppUserId = userId;
            await _client.PutAsJsonAsync("Courses", updateCourseDTO);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CourseVideos(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDTO>>("CourseVideos/GetCourseVideosByCourseID/" + id);

            TempData["courseId"] = id;

            ViewBag.courseName = values.Select(x => x.Course.CourseName).FirstOrDefault();

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateVideo()
        {
            var courseId = (int)TempData["courseId"];
            var course = await _client.GetFromJsonAsync<ResultCourseDTO>("Courses/" + courseId);
            ViewBag.courseName = course.CourseName;
            ViewBag.courseId = course.CourseID;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateCourseVideoDTO model)
        {
            await _client.PostAsJsonAsync("CourseVideos", model);
            return RedirectToAction("Index");
        }
    }
}