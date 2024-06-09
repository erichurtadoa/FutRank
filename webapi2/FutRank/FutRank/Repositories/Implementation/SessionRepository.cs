using FutRank.Models;
using FutRank.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FutRank.Repositories.Implementation
{
    public class SessionRepository : ISessionRepository
    {
        private readonly SampleDBContext _context;

        public SessionRepository(SampleDBContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            //_context.Users.Add(user);
            //_context.SaveChanges();
        }
    }
}
