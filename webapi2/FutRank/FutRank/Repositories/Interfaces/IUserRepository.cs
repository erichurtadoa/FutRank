using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserInfo> GetUserDetailsAsync(Guid userId);
    }
}
