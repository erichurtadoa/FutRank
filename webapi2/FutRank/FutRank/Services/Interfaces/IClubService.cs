using FutRank.Dtos;

namespace FutRank.Services.Interfaces
{
    public interface IClubService
    {
        IEnumerable<ClubDto> GetClubsAsync();
        ClubDetailsDto GetClubByIdAsync(int id);
    }
}
