using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.TeacherSocialMediaDTOs;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MySocialMediaController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialMediaDTO>>("teacherSocialMedias/byTeacherID/" + user.Id);
            return View(values);
        }

        public async Task<IActionResult> DeleteTeacherSocialMedia(int id)
        {
            await _client.DeleteAsync("teacherSocialMedias/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateTeacherSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacherSocialMedia(CreateTeacherSocialMediaDTO createTeacherSocialMediaDTO)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createTeacherSocialMediaDTO.TeacherId = user.Id;
            await _client.PostAsJsonAsync("teacherSocialMedias", createTeacherSocialMediaDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeacherSocialMedia(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateTeacherSocialMediaDTO>("teacherSocialMedias/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeacherSocialMedia(UpdateTeacherSocialMediaDTO updateTeacherSocialMediaDTO)
        {
            await _client.PutAsJsonAsync("teacherSocialMedias", updateTeacherSocialMediaDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("TeacherSocialMedias/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("TeacherSocialMedias/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}