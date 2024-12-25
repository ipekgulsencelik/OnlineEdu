using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.FeatureDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.About
{
    public class _AboutAllFeaturesComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeatureDTO>>("Features/GetAllFeatures");
            return View(values);
        }
    }
}