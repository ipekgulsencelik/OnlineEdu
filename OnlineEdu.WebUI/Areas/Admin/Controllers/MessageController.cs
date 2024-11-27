using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.MessageDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMessageDTO>>("Messages");
            return View(values);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _client.DeleteAsync("Messages/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetail(int id)
        {
            var value = await _client.GetFromJsonAsync<ResultMessageDTO>("Messages/" + id);
            return View(value);
        }
    }
}