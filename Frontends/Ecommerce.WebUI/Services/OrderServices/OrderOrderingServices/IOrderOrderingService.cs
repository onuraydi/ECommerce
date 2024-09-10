using ECommerce.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace Ecommerce.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
