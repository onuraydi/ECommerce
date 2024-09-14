namespace ECommerce.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalMessageCount();
    }
}
