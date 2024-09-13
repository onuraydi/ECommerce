using ECommerce.Discount.Dtos;
using ECommerce.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> discountCouponList()
        {
            var values = await _discountService.GetAllDiscountCouponAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getDiscountCouponById(int id)
        {
            var values = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> createDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createDiscountCouponDto);
            return Ok("Kupon Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> updateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateDiscountCouponDto);
            return Ok("Kupon Başarıyla Güncellendi");
        }

        [HttpGet("GetCodeDetailByCodeAsync")]  
        public async Task<IActionResult> GetCodeDetailByCodeAsync(string couponCode)
        {
            var values = await _discountService.GetCodeDetailByCodeAsync(couponCode);
            return Ok(values);
        }
        [HttpGet("GetDiscountCouponCouponRate")]
        public IActionResult GetDiscountCouponCouponRate(string couponCode)
        {
            var values = _discountService.GetDiscountCouponCouponRate(couponCode);
            return Ok(values);
        }

        [HttpGet("GetDiscountCouponCount")]
        public async Task<IActionResult> GetDiscountCouponCount()
        {
            var values = await _discountService.GetDiscountCouponCount();
            return Ok(values);
        }
    }
}
