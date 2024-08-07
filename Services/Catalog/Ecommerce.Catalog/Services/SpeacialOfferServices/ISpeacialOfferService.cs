using ECommerce.Catalog.Dtos.SpecialOfferDtos;

namespace ECommerce.Catalog.Services.SpeacialOfferServices
{
    public interface ISpeacialOfferService
    {
        Task<List<ResultSpeacialOfferDto>> GetAllSpeacialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
