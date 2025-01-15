using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;
using OnlineEdu.WebUI.Validators;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly HttpClient _client;

        public BlogCategoryController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDTO>>("BlogCategories");
            return View(values);
        }

        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            await _client.DeleteAsync($"BlogCategories/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateBlogCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDTO createBlogCategoryDTO)
        {
            var validator = new BlogCategoryValidator();
            var result = await validator.ValidateAsync(createBlogCategoryDTO);
            if (!result.IsValid)
            {
                ModelState.Clear();
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                return View();
            }
            await _client.PostAsJsonAsync("BlogCategories", createBlogCategoryDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlogCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBlogCategoryDTO>($"BlogCategories/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDTO updateBlogCategoryDTO)
        {
            await _client.PutAsJsonAsync("BlogCategories", updateBlogCategoryDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("BlogCategories/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("BlogCategories/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}