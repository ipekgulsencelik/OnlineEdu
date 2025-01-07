using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDTOs;
using OnlineEdu.WebUI.DTOs.SubscriberDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDTO model)
        {
            await _client.PostAsJsonAsync("Subscribers", model);
            return NoContent();
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _client.GetFromJsonAsync<ResultBlogDTO>("Blogs/" +  id);
            return View(blog);
        }
    }
}