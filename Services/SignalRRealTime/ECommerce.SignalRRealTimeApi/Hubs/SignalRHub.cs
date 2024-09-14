using ECommerce.SignalRRealTimeApi.Services.SignalRCommentServices;
using ECommerce.SignalRRealTimeApi.Services.SignalRMessageServices;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRMessageService _messageService;
        private readonly ISignalRCommentService _commentService;
        public SignalRHub(ISignalRMessageService messageService, ISignalRCommentService commentService)
        {
            _messageService = messageService;
            _commentService = commentService;
        }

        public async Task SendStatisticCount(string id)
        {
            var getTotalCommentCount = _commentService.GetTotalMessageCount();
            await Clients.All.SendAsync("ReceiveCommentCount",getTotalCommentCount);

            var getTotalMessageCount = _messageService.GetTotalMessageCountByRecieverId(id);
            await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
        }
    }
}
