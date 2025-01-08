using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SubscriberDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class UserLayoutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public IActionResult Layout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDTO model)
        {
            await _client.PostAsJsonAsync("Subscribers", model);
            return NoContent();
        }
    }
}