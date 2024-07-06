using FutRank.Dtos;

namespace FutRank.Services.Interfaces
{
    public interface IClubService
    {
        IEnumerable<ClubDto> GetClubsAsync();
        IEnumerable<ClubDto> GetClubsUserAsync(Guid userId);
        ClubDetailsDto GetClubByIdAsync(int id);
        Task VoteClub(bool upVote, Guid userId, int clubId);
        Task AddFavourite(Guid userId, int clubId);
    }
}
