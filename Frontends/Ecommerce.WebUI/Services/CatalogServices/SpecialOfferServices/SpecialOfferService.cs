using ECommerce.DtoLayer.CalatogDtos.ProductDetailDtos;
using ECommerce.DtoLayer.CalatogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync("specialoffers", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialoffers/" + id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpeacialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            return values;
        }

        public async Task<UpdateSpeacialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSpeacialOfferDto>();
            return values;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpeacialOfferDto updateSpeacialOfferDto)
        {
            await _httpClient.PutAsJsonAsync("specialoffers", updateSpeacialOfferDto); 
        }
    }
}
