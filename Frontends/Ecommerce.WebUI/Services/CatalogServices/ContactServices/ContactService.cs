using ECommerce.DtoLayer.CalatogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Ecommerce.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("contacts", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contacts/" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var responseMessage = await _httpClient.GetAsync("contacts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return values;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync("contacts", updateContactDto);
        }
    }
}
