using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Services.OrderServices.OrderOrderingServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IUserService _userService;
        public MyOrderController(IOrderOrderingService orderOrderingService, IUserService userService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> MyOrderList()
        {
            var userValue = await _userService.GetUserInfo();
            var values = await _orderOrderingService.GetOrderingByUserId(userValue.Id);
            return View(values);
        }
    }
}
