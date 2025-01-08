using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.MessageDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO model)
        {
            await _client.PostAsJsonAsync("Messages", model);
            return NoContent();
        }
    }
}