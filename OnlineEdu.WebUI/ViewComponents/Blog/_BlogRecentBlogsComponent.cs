using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDTOs;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogRecentBlogsComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _BlogRecentBlogsComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDTO>>("Blogs/GetLast4Blogs");
            return View(values);
        }
    }
}