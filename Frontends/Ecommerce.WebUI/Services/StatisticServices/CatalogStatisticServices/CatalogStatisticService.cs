
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCountAsync()
        {
            //http://localhost:5000/services/catalog/statistics/GetBrandCount
            var responseMessage =  await _httpClient.GetAsync("statistics/GetBrandCount/");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;

        }

        public async Task<long> GetCategoryCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetCategoryCount/");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMaxPriceProductName/");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMinPriceProductName/");
            var values = await responseMessage.Content.ReadAsStringAsync(); 
            return values;
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetproductAveragePrice/");
            var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return values;
        }

        public async Task<long> GetProductCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductCount/");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
    }
}
