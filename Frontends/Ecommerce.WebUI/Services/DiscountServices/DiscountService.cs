using ECommerce.DtoLayer.DiscountDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _httpClient.PostAsJsonAsync("discounts", createDiscountCouponDto);
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            await _httpClient.DeleteAsync("discounts/" + id);
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            var responseMessage = await _httpClient.GetAsync("discounts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountCouponDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("discounts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdDiscountCouponDto>();
            return values;
        }

        public async Task<GetDiscountCouponDetailByCode> GetDiscountCode(string couponCode)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/discount/discounts/GetCodeDetailByCode?couponCode=" + couponCode);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCouponDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponCouponRate(string couponCode)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/discount/discounts/GetDiscountCouponCouponRate?couponCode=" + couponCode);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values; ;
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _httpClient.PutAsJsonAsync("discounts", updateDiscountCouponDto);
        }
    }
}
