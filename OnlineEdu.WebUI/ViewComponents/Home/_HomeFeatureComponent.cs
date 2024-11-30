using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.FeatureDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeFeatureComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeatureDTO>>("Features/GetLast4Features");
            return View(values);
        }
    }
}
