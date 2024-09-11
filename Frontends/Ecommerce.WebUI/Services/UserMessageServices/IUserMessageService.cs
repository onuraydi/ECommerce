using ECommerce.DtoLayer.MessageDtos;

namespace Ecommerce.WebUI.Services.UserMessageServices
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}
