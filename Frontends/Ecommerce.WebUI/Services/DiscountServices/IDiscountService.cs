using ECommerce.DtoLayer.DiscountDtos;

namespace Ecommerce.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCouponDetailByCode> GetDiscountCode(string couponCode);
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
        Task<int> GetDiscountCouponCouponRate(string couponCode);
    }
}
    