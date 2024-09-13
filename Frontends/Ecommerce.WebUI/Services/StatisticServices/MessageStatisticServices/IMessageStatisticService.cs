namespace Ecommerce.WebUI.Services.StatisticServices.MessageStatisticService
{
    public interface IMessageStatisticService
    {
        Task<int> GetTotalMessageCountAsync();
    }
}
