using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TestimonialDTOs;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeTestimonialComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeTestimonialComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDTO>>("Testimonials/GetActiveTestimonials");
            return View(values);
        }
    }
}