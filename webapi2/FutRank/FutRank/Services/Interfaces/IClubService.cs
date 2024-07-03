using FutRank.Dtos;

namespace FutRank.Services.Interfaces
{
    public interface IClubService
    {
        IEnumerable<ClubDto> GetClubsAsync();
        ClubDetailsDto GetClubByIdAsync(int id);

        Task VoteClub(bool upVote, Guid userId, int clubId);
    }
}
