using ECommerce.DtoLayer.CalatogDtos.ProductDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDtoAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync("products", createProductDto);
        }

        public async Task DeleteProductDtoAsync(string id)
        {
            await _httpClient.DeleteAsync("products/" + id);
        }
            
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }

        public Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductDtoAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync("products", updateProductDto);
        }
    }
}
