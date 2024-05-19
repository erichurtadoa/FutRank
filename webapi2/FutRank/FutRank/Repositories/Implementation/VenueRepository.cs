using FutRank.Models;
using FutRank.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FutRank.Repositories.Implementation
{
    public class VenueRepository : IVenueRepository
    {
        private readonly SampleDBContext _context;

        public VenueRepository(SampleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Venue> GetVenuesAsync()
        {
            return _context.Venues.ToList();
        }
    }
}
