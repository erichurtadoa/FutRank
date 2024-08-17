using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Services.Interfaces
{
    public interface IForumService
    {
        Task<IEnumerable<ForumThreadDto>> GetForumAsync();
        Task<ForumThreadDto> GetThreadByIdAsync(int id);
        Task<ForumThreadDto> CreateThreadAsync(string title, Guid userId);
        Task<CommentDto> CreateCommentAsync(int id, string content, Guid userId);
    }
}
