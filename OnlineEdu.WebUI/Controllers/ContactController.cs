using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDTOs;
using OnlineEdu.WebUI.DTOs.MessageDTOs;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDTO>>("Contacts");
            ViewBag.map = values.Select(x => x.MapUrl).FirstOrDefault();
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