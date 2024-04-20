using FutRank.Models;

namespace FutRank.Repositories
{
    public interface IClubRepository
    {
        IEnumerable<Club> GetClubsAsync();
    }
}
