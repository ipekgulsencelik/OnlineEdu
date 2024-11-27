using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCounterComponent(IUserService _userService) : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.blogCount = await _client.GetFromJsonAsync<int>("Blogs/GetBlogCount");
            ViewBag.courseCount = await _client.GetFromJsonAsync<int>("Courses/GetCourseCount");
            ViewBag.courseCategoryCount = await _client.GetFromJsonAsync<int>("courseCategories/GetCourseCategoryCount");
            ViewBag.testimonialCount = await _client.GetFromJsonAsync<int>("Testimonials/GetTestimonialCount");

            return View();
        }
    }
}