using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.LoginDTOs;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Services.UserServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _client;
        private readonly IUserService _userService;
        
        public LoginController(IHttpClientFactory clientFactory, IUserService userService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _userService = userService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDTO userLoginDTO)
        {
            var result = await _client.PostAsJsonAsync("Users/Login", userLoginDTO);

            if (!result.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View(userLoginDTO);
            }

            var handler = new JwtSecurityTokenHandler();
            var response = await result.Content.ReadFromJsonAsync<LoginResponseDTO>();
            var token = handler.ReadJwtToken(response.Token);
            var claims = token.Claims.ToList();

            if (response.Token != null)
            {
                claims.Add(new Claim("Token", response.Token));
                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    ExpiresUtc = response.ExpireDate,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                var userRole = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                return userRole switch
                {
                    "Admin" => RedirectToAction("Index", "About", new { area = "Admin" }),
                    "Teacher" => RedirectToAction("Index", "MyCourse", new { area = "Teacher" }),
                    "Student" => RedirectToAction("Index", "CourseRegister", new { area = "Student" }),
                    _ => RedirectToAction("SignIn")
                };
            }
            ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");

            return View(userLoginDTO);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}