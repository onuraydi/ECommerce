using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Services.UserMessageServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IUserMessageService _messageService;
        private readonly IUserService _userService;
        public MessageController(IUserMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var userValue = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessageAsync(userValue.Id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> SendBox()
        {
            var userValue = await _userService.GetUserInfo();
            var values = await _messageService.GetSendboxMessageAsync(userValue.Id);
            return View(values);
        }
    }
}
