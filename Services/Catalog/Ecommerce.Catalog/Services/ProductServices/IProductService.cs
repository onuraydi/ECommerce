using Ecommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Dtos.ProductDtos;

namespace Ecommerce.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductDtoAsync(CreateProductDto createProductDto);
        Task UpdateProductDtoAsync(UpdateProductDto updateProductDto);
        Task DeleteProductDtoAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
    }
}
