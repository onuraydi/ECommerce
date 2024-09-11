using ECommerce.Message.Dtos;
using ECommerce.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace ECommerce.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly IUserMessageService _messageService;

        public MessagesController(IUserMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _messageService.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _messageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj Başarıyla oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteMessageAsync(id);
            return Ok("Mesaj Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _messageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var values = await _messageService.GetByIdMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMessageSendBox/{id}")]
        public async Task<IActionResult> GetMessageSendBox(string id)
        {
            var values = await _messageService.GetSendboxMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMessageInBox/{id}")]
        public async Task<IActionResult> GetMessageInBox(string id)
        {
            var values = await _messageService.GetInboxMessageAsync(id);
            return Ok(values);
        } 
    }
}
