using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDTOs;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client;

        public AboutController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDTO>>("Abouts");
            return View(values);
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _client.DeleteAsync($"Abouts/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            await _client.PostAsJsonAsync("Abouts", createAboutDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateAboutDTO>($"Abouts/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            await _client.PutAsJsonAsync("Abouts", updateAboutDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Abouts/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Abouts/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}