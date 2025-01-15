using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDTOs;

namespace OnlineEdu.WebUI.ViewComponents.UserLayout
{
    public class _UserILayoutSocialMediaComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _UserILayoutSocialMediaComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialMedias = await _client.GetFromJsonAsync<List<ResultSocialMediaDTO>>("SocialMedias");
            return View(socialMedias);
        }
    }
}