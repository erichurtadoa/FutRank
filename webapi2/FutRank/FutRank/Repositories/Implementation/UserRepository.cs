using FutRank.Models;
using FutRank.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FutRank.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly SampleDBContext _context;

        public UserRepository(SampleDBContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetUserDetailsAsync(Guid userId)
        {
            return await _context.UsersInfo
                .Where(u => u.Id == userId)
                .Include(u => u.UserClubs)
                    .ThenInclude(c => c.Club)
                        .ThenInclude(c => c.Country)
                .Include(u => u.UserFixtures)
                    .ThenInclude(f => f.Fixture)
                        .ThenInclude(f => f.AwayClub)
                .Include(u => u.UserFixtures)
                    .ThenInclude(f => f.Fixture)
                        .ThenInclude(f => f.HomeClub)
                .Include(u => u.UserFixtures)
                    .ThenInclude(f => f.Fixture)
                        .ThenInclude(f => f.League)
                .Include(u => u.FavouriteClub)
                .FirstOrDefaultAsync();
        }
    }
}
