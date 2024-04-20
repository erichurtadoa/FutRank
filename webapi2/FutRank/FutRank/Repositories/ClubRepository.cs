using FutRank.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FutRank.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly SampleDBContext _context;

        public ClubRepository(SampleDBContext context) 
        {
            _context = context;
        }

        public IEnumerable<Club> GetClubsAsync()
        {
            return _context.Clubs.Include(club => club.Venue).ToList();
        }
    }
}
