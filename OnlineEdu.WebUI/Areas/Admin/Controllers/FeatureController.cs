﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}