using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDTOs;

namespace OnlineEdu.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly HttpClient _client;

        public AboutController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDTO>>("Abouts/GetActiveAbouts");
            return View(values);
        }
    }
}