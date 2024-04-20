using FutRank.Models;

namespace FutRank.Repositories
{
    public interface IVenueRepository
    {
        IEnumerable<Venue> GetVenuesAsync();
    }
}
