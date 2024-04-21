using FutRank.Models;

namespace FutRank.Services.Interfaces
{
    public interface IVenueService
    {
        IEnumerable<Venue> GetVenuesAsync();
    }
}
