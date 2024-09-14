using AutoMapper;
using ECommerce.Message.Dal.Context;
using ECommerce.Message.Dal.Entites;
using ECommerce.Message.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(value);
            _messageContext.SaveChanges();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(values);            
            _messageContext.SaveChanges();
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var value = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(value);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(value);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var value = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(value);
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
            var value = await _messageContext.UserMessages.CountAsync();
            return value;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var value = await _messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(value);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<UserMessage>(updateMessageDto);
            _messageContext.UserMessages.Update(value);
            _messageContext.SaveChanges();
        }

        public async Task<int> GetTotalMessageCountByRecieverId(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
            return values;  
        }
    }
}
