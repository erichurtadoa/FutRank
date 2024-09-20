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

        public async Task<IEnumerable<Fixture>> GetFixturesAsync(FixtureFilter filter)
        {
            var query = _context.Fixture
            .Include(f => f.Venue)
            .Include(f => f.League)
            .Include(f => f.HomeClub)
            .Include(f => f.AwayClub)
            .Include(f => f.UserFixtures)
            .AsQueryable();

            if (!string.IsNullOrEmpty(filter.League))
            {
                query = query.Where(f => f.League.Name == filter.League);
            }

            if (!string.IsNullOrEmpty(filter.Season))
            {
                query = query.Where(f => f.Season == filter.Season);
            }

            if (!string.IsNullOrEmpty(filter.Team))
            {
                query = query.Where(f => f.HomeClub.Name.Contains(filter.Team) || f.AwayClub.Name.Contains(filter.Team));
            }

            return await query.ToListAsync();
        }

        public async Task<Fixture> GetFixtureByIdAsync(int id)
        {
             return await _context.Fixture
            .Include(f => f.Venue)
            .Include(f => f.League)
            .Include(f => f.HomeClub)
            .Include(f => f.AwayClub)
            .Include(f => f.UserFixtures)
            .Include(f => f.Comments)
            .Where(fixture => fixture.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task VoteFixtureAsync(UserFixtures userFixture)
        {
            var existedUser = await _context.UserFixtures.Where(x => x.UserId == userFixture.UserId && x.FixtureId == userFixture.FixtureId).FirstOrDefaultAsync();
            var fixture = await _context.Fixture.Where(x => x.Id == userFixture.FixtureId).FirstOrDefaultAsync();
            var user = await _context.UsersInfo.Where(x => x.Id == userFixture.UserId).FirstOrDefaultAsync();

            if (existedUser != null)
            {
                if (userFixture.UserNote == null)
                {
                    _context.UserFixtures.Remove(existedUser);
                    user.FixtureTime -= fixture.Time;
                }
                else
                {
                    existedUser.UserNote = userFixture.UserNote;
                }
            }

            else
            {
                _context.UserFixtures.Add(userFixture);
                user.FixtureTime += fixture.Time;
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

                var fixtureNote = (float)auxNote / totalNotes;

                fixture.Rate = fixtureNote;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<CommentFixture> CreateCommentAsync(int id, string content, Guid userId)
        {
            var user = _context.UsersInfo.Where(u => u.Id == userId).FirstOrDefault();
            var comment = new CommentFixture
            {
                Content = content,
                CreatedAt = DateTime.UtcNow,
                Creator = user.Username,
                FixtureId = id
            };

            _context.CommentFixture.Add(comment);

            _context.SaveChanges();

            return comment;
        }
    }
}
