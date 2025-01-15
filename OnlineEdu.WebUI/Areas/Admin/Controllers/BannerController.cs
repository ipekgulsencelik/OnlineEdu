using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BannerDTOs;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BannerController(IHttpClientFactory clientFactory, IWebHostEnvironment webHostEnvironment)
        {
            _client = clientFactory.CreateClient("EduClient");
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDTO>>("Banners");
            return View(values);
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _client.DeleteAsync($"Banners/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDTO createBannerDTO)
        {
            await _client.PostAsJsonAsync("Banners", createBannerDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBannerDTO>($"Banners/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDTO updateBannerDTO, IFormFile image)
        {
            string uniqueImageName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/banner");
                uniqueImageName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueImageName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                updateBannerDTO.ImageUrl = uniqueImageName;
            }
            else
            {
                updateBannerDTO.ImageUrl = updateBannerDTO.ImageUrl;
            }
            await _client.PutAsJsonAsync("Banners", updateBannerDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Banners/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Banners/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}