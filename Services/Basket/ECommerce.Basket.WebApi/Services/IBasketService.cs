using ECommerce.Basket.WebApi.Dtos;

namespace ECommerce.Basket.WebApi.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string UserId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string UserId);
    }
}
