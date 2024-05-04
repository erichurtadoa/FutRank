using FutRank.Models;
using FutRank.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FutRank.Repositories.Implementation
{
    public class FixtureRepository : IFixtureRepository
    {
        private readonly SampleDBContext _context;

        public FixtureRepository(SampleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Fixture> GetFixturesAsync()
        {
            var fixture =  _context.Fixture.Include(fixture => fixture.Venue)
                .Include(fixture => fixture.League)
                .Include(fixture => fixture.HomeClub)
                .Include(fixture => fixture.AwayClub)
                .ToList();
            return fixture;
        }
    }
}
