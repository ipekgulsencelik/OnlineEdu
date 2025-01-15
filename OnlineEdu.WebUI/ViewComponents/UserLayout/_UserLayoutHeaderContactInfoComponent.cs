using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDTOs;

namespace OnlineEdu.WebUI.ViewComponents.UserLayout
{
    public class _UserLayoutHeaderContactInfoComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _UserLayoutHeaderContactInfoComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<ResultContactDTO>("Contacts/GetContact");
            return View(values);
        }
    }
}