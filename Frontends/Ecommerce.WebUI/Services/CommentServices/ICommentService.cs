using ECommerce.DtoLayer.CommentDtos;

namespace Ecommerce.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllComentAsync();
        Task<List<ResultCommentDto>> CommentListByProductId(string id);
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(int id);
        Task<UpdateCommentDto> GetByIdCommentAsync(int id);
        Task<int> GetTotalCommentCountAsync();
        Task<int> GetActiveCommentCountAsync();
        Task<int> GetPassiveCommentCountAsync();
    }
}
