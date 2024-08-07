using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TakeAway.Comment.DAL.Context;
using TakeAway.Comment.DAL.Entities;
using TakeAway.Comment.Dtos;

namespace TakeAway.Comment.Services
{
    public class UserCommentService : IUserCommentService
    {
        private readonly CommentContext _commentContext;
        private readonly IMapper _mapper;

        public UserCommentService(CommentContext commentContext, IMapper mapper)
        {
            _commentContext = commentContext;
            _mapper = mapper;
        }

        public async Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto)
        {
            var value = _mapper.Map<UserComment>(createUserCommentDto);
            await _commentContext.UserComments.AddAsync(value);
            await _commentContext.SaveChangesAsync();
        }

        public async Task DeleteUserCommentAsync(int id)
        {
            var values = await _commentContext.UserComments.FindAsync(id);
            _commentContext.UserComments.Remove(values);
            await _commentContext.SaveChangesAsync();
        }

        public async Task<List<ResultUserCommentDto>> GetAllUserCommentAsync()
        {
            var values =await _commentContext.UserComments.ToListAsync();
            return _mapper.Map<List<ResultUserCommentDto>>(values);
        }

        public async Task<GetByIdUserCommentDto> GetByIdUserCommentAsync(int id)
        {
            var value = await _commentContext.UserComments.FindAsync(id);
            return _mapper.Map<GetByIdUserCommentDto>(value);
        }

        public async Task<List<ResultUserCommentDto>> GetProductUserCommentAsync(string productId)
        {
            var value = await _commentContext.UserComments.Where(x => x.ProductId == productId).ToListAsync();
            return _mapper.Map<List<ResultUserCommentDto>>(value);
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto)
        {
            var values = _mapper.Map<UserComment>(updateUserCommentDto);
            _commentContext.UserComments.Update(values);
            await _commentContext.SaveChangesAsync();
        }
    }
}
