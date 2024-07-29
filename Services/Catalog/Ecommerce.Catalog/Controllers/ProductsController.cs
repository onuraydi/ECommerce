using Ecommerce.Catalog.Dtos.ProductDtos;
using Ecommerce.Catalog.Services.CategoryServices;
using Ecommerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> productList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getProductById(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> createProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductDtoAsync(createProductDto);
            return Ok("Ürün Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> deleteProduct(string id)
        {
            await _productService.DeleteProductDtoAsync(id);
            return Ok("Ürün Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> updateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductDtoAsync(updateProductDto);
            return Ok("Ürün Başarıyla Güncellendi");
        }
    }
}
