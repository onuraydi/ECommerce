using Ecommerce.WebUI.Services.CommentServices;
using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Services.UserMessageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace Ecommerce.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponent
{
    public class _AdminLayoutHeaderComponentPartial :ViewComponent
    {
        private readonly IUserMessageService _userMessageService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        public _AdminLayoutHeaderComponentPartial(IUserMessageService userMessageService, IUserService userService, ICommentService commentService)
        {
            _userMessageService = userMessageService;
            _userService = userService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = await _userService.GetUserInfo();
            int messageCount = await _userMessageService.GetTotalMessageCountByRecieverId(id.Id);
            ViewBag.MessageCount = messageCount;

            var totalCommentCount = await _commentService.GetTotalCommentCountAsync();
            ViewBag.TotalCommentCount = totalCommentCount;

            return View();
        }
    }
}
