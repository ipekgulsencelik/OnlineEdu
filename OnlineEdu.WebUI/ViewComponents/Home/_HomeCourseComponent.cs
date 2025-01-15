﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDTOs;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCourseComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeCourseComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDTO>>("courses/GetActiveCourses");
            return View(values);
        }
    }
}