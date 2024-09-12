using ECommerce.DtoLayer.IdentityDtos.UserDtos;

namespace Ecommerce.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUser();
    }
}
