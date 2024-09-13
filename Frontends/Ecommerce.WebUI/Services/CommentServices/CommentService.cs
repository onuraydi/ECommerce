using ECommerce.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"comments/CommentListByProductId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return values;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync("comments", createCommentDto);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _httpClient.DeleteAsync("comments/" + id);
        }

        public async Task<int> GetActiveCommentCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetActiveCommentCount/");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<List<ResultCommentDto>> GetAllComentAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return values;
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetPassiveCommentCount/");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetTotalCommentCount/");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync("comments", updateCommentDto);
        }
    }
}
