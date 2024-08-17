using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IForumRepository
    {
        Task<IEnumerable<ForumThread>> GetForumAsync();
        Task<ForumThread> GetThreadById(int id);
        Task<ForumThread> CreateThreadAsync(string title, Guid userId);
        Task<Comment> CreateCommentAsync(int id, string content, Guid userId);
    }
}
