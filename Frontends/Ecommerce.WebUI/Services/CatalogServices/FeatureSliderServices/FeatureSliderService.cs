using ECommerce.DtoLayer.CalatogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync("featuresliders",createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featuresliders/"+id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();  // daha sonra backendede yazılmadı
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException(); // daha sonra
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
            return values;
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
            return values;  
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync("featuresliders", updateFeatureSliderDto);
        }
    }
}
