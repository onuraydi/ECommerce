using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
        Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string couponCode);
        int GetDiscountCouponCouponRate(string couponCode);
        Task<int> GetDiscountCouponCount();
    }
}
