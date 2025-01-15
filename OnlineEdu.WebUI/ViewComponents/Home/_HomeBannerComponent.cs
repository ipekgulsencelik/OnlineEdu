using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BannerDTOs;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeBannerComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeBannerComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDTO>>("Banners/GetActiveBanners");
            return View(values);
        }
    }
}