using ECommerce.DtoLayer.OrderDtos.OrderAddressDtos;

namespace Ecommerce.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        // Not: Diğer İşlemler Daha sonra eklenecek şuan test için sadece ekleme Task'i yazılı
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    }
}
