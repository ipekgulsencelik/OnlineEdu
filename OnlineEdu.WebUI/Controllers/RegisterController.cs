using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _client;

        public RegisterController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDTO userRegisterDTO)
        {
            var result = await _client.PostAsJsonAsync("Users/Register", userRegisterDTO);

            if (!ModelState.IsValid)
            {
                return View(userRegisterDTO);
            }

            if (!result.IsSuccessStatusCode)
            {
                var errors = await result.Content.ReadFromJsonAsync<List<RegisterResponseDTO>>();

                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(userRegisterDTO);
            }

            return RedirectToAction("SignIn", "Login");
        }
    }
}