﻿using ECommerce.Message.Dtos;

namespace ECommerce.Message.Services
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
        Task<int> GetTotalMessageCountAsync();
        Task<int> GetTotalMessageCountByRecieverId(string id);
    }
}
