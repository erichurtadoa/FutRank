using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IVenueRepository
    {
        IEnumerable<Venue> GetVenuesAsync();
    }
}
