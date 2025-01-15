﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDTOs;

namespace OnlineEdu.WebUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDTO>>("Courses");
            return View(courses);
        }

        public async Task<IActionResult> GetCoursesByCategoryID(int id)
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDTO>>("Courses/GetCoursesByCategoryID/" + id);
            var category = (from x in courses
                            select x.CourseCategory.Name).FirstOrDefault();
            ViewBag.category = category;

            return View(courses);
        }
    }
}
