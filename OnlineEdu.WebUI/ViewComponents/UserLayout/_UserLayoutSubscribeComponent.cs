using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.ViewComponents.UserLayout
{
    public class _UserLayoutSubscribeComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}