using ECommerce.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Message.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageStatisticController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageStatisticController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var mmessageCount = await _userMessageService.GetTotalMessageCountAsync();
            return Ok(mmessageCount);
        }
    }
}
