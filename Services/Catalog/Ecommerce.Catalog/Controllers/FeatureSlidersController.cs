using ECommerce.Catalog.Dtos.FeatureSliderDtos;
using ECommerce.Catalog.Services.FetaureSliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace ECommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IfeatureSliderService _featureSliderService;
        public FeatureSlidersController(IfeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne Çıkanlar Kısmına Başarıyla Ekleme İşlemi Gerçekleştirildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne Çıkanlar kısmındaki Silme işlemi Başarıyla Gerçekleştirildi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne Çıkanlar Kısmında Güncelleme İşlemi Başarıyla Gerçekleştirildi");
        }
    }
}
