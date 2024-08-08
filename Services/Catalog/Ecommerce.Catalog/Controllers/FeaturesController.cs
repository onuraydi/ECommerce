using ECommerce.Catalog.Dtos.FeatureDtos;
using ECommerce.Catalog.Services.FeatureServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var values = await _featureService.GetByIdFeatureAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Öne Çıkanlar Kısmına Başarıyla Ekleme İşlemi Gerçekleştirildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Öne Çıkanlar kısmındaki Silme işlemi Başarıyla Gerçekleştirildi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Öne Çıkanlar Kısmında Güncelleme İşlemi Başarıyla Gerçekleştirildi");
        }
    }
}
