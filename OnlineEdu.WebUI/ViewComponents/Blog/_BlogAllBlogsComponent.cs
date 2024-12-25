﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogAllBlogsComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDTO>>("Blogs");
            return View(values);
        }
    }
}