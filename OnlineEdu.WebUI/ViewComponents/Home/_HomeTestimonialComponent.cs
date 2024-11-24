using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TestimonialDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeTestimonialComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDTO>>("Testimonials");
            return View(values);
        }
    }
}