using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.UserLayout
{
    public class _UserLayoutHeaderContactInfoComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<ResultContactDTO>("Contacts/GetContact");
            return View(values);
        }
    }
}