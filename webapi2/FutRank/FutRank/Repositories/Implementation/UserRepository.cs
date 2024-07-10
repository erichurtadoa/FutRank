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
            return (UserInfo)await _context.UsersInfo
                .Where(u => u.Id == userId)
                .Include(u => u.UserClubs)
                .Include(u => u.UserFixtures)
                .Include(u => u.FavouriteClub)
                .FirstOrDefaultAsync();
        }
    }
}
