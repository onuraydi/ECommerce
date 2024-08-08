using ECommerce.Catalog.Dtos.OfferDiscountDtos;
using ECommerce.Catalog.Services.OfferDiscountServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountsController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> ListOfferDiscount()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOfferDiscount(string id)
        {
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("İndirim Ekleme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("İndirim Güncelleme İşlemi Başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("İndirim Silme İşlemi Başarılı");
        }
    }
}
