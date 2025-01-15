using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TeacherSocialMediaDTOs;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MySocialMediaController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public MySocialMediaController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialMediaDTO>>("teacherSocialMedias/byTeacherID/" + userId);
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
            var userId = _tokenService.GetUserId;
            createTeacherSocialMediaDTO.TeacherId = userId;
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