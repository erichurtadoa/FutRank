using FutRank.Models;

namespace FutRank.Services.Interfaces
{
    public interface IClubService
    {
        IEnumerable<Club> GetClubsAsync();
    }
}
