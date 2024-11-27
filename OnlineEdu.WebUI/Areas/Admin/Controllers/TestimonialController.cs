using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TestimonialDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDTO>>("Testimonials");
            return View(values);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _client.DeleteAsync($"Testimonials/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            await _client.PostAsJsonAsync("Testimonials", createTestimonialDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateTestimonialDTO>($"Testimonials/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            await _client.PutAsJsonAsync("Testimonials", updateTestimonialDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}