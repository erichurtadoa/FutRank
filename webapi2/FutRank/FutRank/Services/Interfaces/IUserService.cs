using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailsDto> GetUserDetailsAsync(Guid userId);
    }
}
