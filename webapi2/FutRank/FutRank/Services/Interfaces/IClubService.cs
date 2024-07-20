using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Services.Interfaces
{
    public interface IClubService
    {
        IEnumerable<ClubDto> GetClubsAsync(ClubFilter filter);
        IEnumerable<ClubDto> GetClubsUserAsync(Guid userId, ClubFilter filter);
        Task<IEnumerable<ClubDto>> GetOnlyClubsUserAsync(Guid userId);
        ClubDetailsDto GetClubByIdAsync(int id);
        Task VoteClub(bool upVote, Guid userId, int clubId);
        Task AddFavourite(Guid userId, int clubId);
    }
}
