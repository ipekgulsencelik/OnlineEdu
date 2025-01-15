using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.FeatureDTOs;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureController : Controller
    {
        private readonly HttpClient _client;

        public FeatureController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeatureDTO>>("Features");
            return View(values);
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _client.DeleteAsync("Features/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            await _client.PostAsJsonAsync("Features", createFeatureDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateFeatureDTO>("Features/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            await _client.PutAsJsonAsync("Features", updateFeatureDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Features/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Features/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}