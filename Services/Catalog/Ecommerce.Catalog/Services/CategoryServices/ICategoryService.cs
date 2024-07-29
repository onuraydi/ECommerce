using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Entities;

namespace Ecommerce.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();   // Bütün verileri getirecek metot'un imzası
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);  // Yeni Kategori verisi oluşturacağımız metodun imzası
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);  // Güncelleme
        Task DeleteCategoryAsync(string id);  //silme
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);  // ID'ye göre getirme
    }
}
