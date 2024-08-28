using ECommerce.DtoLayer.CalatogDtos.ProductDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {

        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductDtoAsync(CreateProductDto createProductDto);
        Task UpdateProductDtoAsync(UpdateProductDto updateProductDto);
        Task DeleteProductDtoAsync(string id);
        Task<UpdateProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
    }
}
