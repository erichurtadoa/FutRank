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

        public async Task<IEnumerable<Fixture>> GetFixturesAsync()
        {
            var fixture =  _context.Fixture.Include(fixture => fixture.Venue)
                .Include(fixture => fixture.League)
                .Include(fixture => fixture.HomeClub)
                .Include(fixture => fixture.AwayClub)
                .Include(fixture => fixture.UserFixtures)
                .ToList();
            return fixture;
        }

        public async Task VoteFixtureAsync(UserFixtures userFixture)
        {
            var existedUser = await _context.UserFixtures.Where(x => x.UserId == userFixture.UserId && x.FixtureId == userFixture.FixtureId).FirstOrDefaultAsync();

            if (existedUser != null)
            {
                existedUser.UserNote = userFixture.UserNote;
            }

            else
            {
                _context.UserFixtures.Add(userFixture);
            }

            _context.SaveChanges();
        }

        public async Task UpdateFixtureNoteAsync(int fixtureId)
        {
            var notes = await _context.UserFixtures
            .Where(uc => uc.FixtureId == fixtureId && uc.UserNote != null)
            .Select(uc => uc.UserNote)
            .ToListAsync();

            var totalNotes = notes.Count();

            var fixture = await _context.Fixture.FirstOrDefaultAsync(c => c.Id == fixtureId);

            if (totalNotes == 0)
            {
                fixture.Rate = null;
            }

            else
            {
                var auxNote = notes.Aggregate(0, (sum, n) => (int)(sum + n));

                var fixtureNote = (float)(auxNote / totalNotes);

                fixture.Rate = fixtureNote;
            }
            await _context.SaveChangesAsync();
        }
    }
}
