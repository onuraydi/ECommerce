using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
