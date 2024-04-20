using FutRank.Models;
using System.Collections.Generic;
using System.Linq;

namespace FutRank.Repositories
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
