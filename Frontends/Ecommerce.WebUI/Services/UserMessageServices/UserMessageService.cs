using ECommerce.DtoLayer.MessageDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.UserMessageServices
{
    public class UserMessageService : IUserMessageService
    {
        private readonly HttpClient _httpClient;

        public UserMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _httpClient.PostAsJsonAsync("/services/message/messages", createMessageDto);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _httpClient.DeleteAsync("/services/message/messages/" + id);
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("/services/message/messages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("/services/message/messages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdMessageDto>();
            return values;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("/services/message/messages/GetMessageInBox/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultInboxMessageDto>>(jsonData);
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("/services/message/messages/GetMessageSendBox/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSendboxMessageDto>>(jsonData);
            return values;
        }

        public async Task<int> GetTotalMessageCountByRecieverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("/services/message/messages/GetTotalMessageCountByRecieverId?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _httpClient.PutAsJsonAsync("messages", updateMessageDto);
        }
    }
}
