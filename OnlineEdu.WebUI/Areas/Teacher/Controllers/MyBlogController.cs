using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;
using OnlineEdu.WebUI.DTOs.BlogDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MyBlogController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultBlogDTO>>("Blogs/GetBlogByWriterID/" + user.Id);
            return View(values);
        }

        public async Task BlogCategoryDropDownAsync()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultBlogCategoryDTO>>("blogCategories");

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.BlogCategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
        }

        public async Task<IActionResult> CreateBlog()
        {
            await BlogCategoryDropDownAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDTO createBlogDTO)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createBlogDTO.WriterId = user.Id;
            await _client.PostAsJsonAsync("Blogs", createBlogDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBlog(int id)
        {
            await BlogCategoryDropDownAsync();
            var value = await _client.GetFromJsonAsync<UpdateBlogDTO>("Blogs/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDTO updateBlogDTO)
        {
            await _client.PutAsJsonAsync("Blogs", updateBlogDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync("Blogs/" + id);
            return RedirectToAction("Index");
        }
    }
}