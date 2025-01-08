using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.Controllers
{
    public class UserLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}