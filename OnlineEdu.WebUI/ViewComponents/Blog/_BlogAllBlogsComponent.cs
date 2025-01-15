using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDTOs;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogAllBlogsComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _BlogAllBlogsComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDTO>>("Blogs");
            return View(values);
        }
    }
}