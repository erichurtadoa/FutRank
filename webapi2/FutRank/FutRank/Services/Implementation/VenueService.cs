using FutRank.Models;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FutRank.Services.Implementation
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository _venueRepository;

        public VenueService(IVenueRepository venueRepository) 
        {
            _venueRepository = venueRepository;
        }

        public IEnumerable<Venue> GetVenuesAsync()
        {
            return _venueRepository.GetVenuesAsync();
        }
    }
}
