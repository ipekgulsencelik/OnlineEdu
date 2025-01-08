using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.UserLayout
{
    public class _UserILayoutSocialMediaComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialMedias = await _client.GetFromJsonAsync<List<ResultSocialMediaDTO>>("SocialMedias");
            return View(socialMedias);
        }
    }
}