using ECommerce.DtoLayer.CalatogDtos.SpecialOfferDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpeacialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpeacialOfferDto updateSpeacialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<UpdateSpeacialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
