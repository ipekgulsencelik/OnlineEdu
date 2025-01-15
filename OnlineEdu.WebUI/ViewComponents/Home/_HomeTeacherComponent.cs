using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeTeacherComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeTeacherComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultUserDTO>>("Users/Get4Teachers"); ;
            return View(values);
        }
    }
}