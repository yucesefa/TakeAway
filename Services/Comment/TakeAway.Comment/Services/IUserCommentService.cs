using TakeAway.Comment.Dtos;

namespace TakeAway.Comment.Services
{
    public interface IUserCommentService
    {
        Task<List<ResultUserCommentDto>> GetAllUserCommentAsync();
        Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto);
        Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto);
        Task DeleteUserCommentAsync(int id);
        Task<GetByIdUserCommentDto> GetByIdUserCommentAsync(int id);

        Task<List<ResultUserCommentDto>> GetProductUserCommentAsync(string productId);
    }
}
