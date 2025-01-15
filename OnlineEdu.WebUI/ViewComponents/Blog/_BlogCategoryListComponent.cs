using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogCategoryListComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _BlogCategoryListComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultBlogCategoryDTO>>("BlogCategories");

            var categories = categoryList.Where(category => category.IsShown)
              .Select(category => new BlogCategoryWithCountViewModel
              {
                  CategoryName = category.Name,
                  BlogCount = category.Blogs?.Count ?? 0,
                  BlogCategoryID = category.BlogCategoryID
              }).ToList();

            return View(categories);
        }
    }
}