using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _client.GetFromJsonAsync<List<ResultAboutDTO>>("Abouts");
            return View(about);
        }
    }
}