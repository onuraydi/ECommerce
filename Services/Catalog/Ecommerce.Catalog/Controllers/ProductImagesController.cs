using Ecommerce.Catalog.Dtos.ProductImageDtos;
using Ecommerce.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("ProductImagesByProductId/{id}")]
        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getProductImageById(string id)
        {
            var values = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> createProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Üün Resmi başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün Resmi Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> updateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün Resmi Başarıyla Güncellendi");
        }
    }
}
