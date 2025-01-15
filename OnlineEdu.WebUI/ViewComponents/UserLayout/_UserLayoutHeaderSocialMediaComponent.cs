using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDTOs;

namespace OnlineEdu.WebUI.ViewComponents.UserLayout
{
    public class _UserLayoutHeaderSocialMediaComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _UserLayoutHeaderSocialMediaComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDTO>>("SocialMedias/GetLast4SocialMedias");
            return View(values);
        }
    }
}