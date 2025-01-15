using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDTOs;

namespace OnlineEdu.WebUI.ViewComponents.Contact
{
    public class _ContactInfoComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _ContactInfoComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDTO>>("Contacts");
            return View(values);
        }
    }
}