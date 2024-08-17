using FutRank.Dtos;
using FutRank.Models;
using FutRank.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FutRank.Repositories.Implementation
{
    public class ForumRepository : IForumRepository
    {
        private readonly SampleDBContext _context;

        public ForumRepository(SampleDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ForumThread>> GetForumAsync()
        {
            return await _context.ForumThread
                .Include(t => t.Comments)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<ForumThread> GetThreadById(int id)
        {
            return await _context.ForumThread
                .Include(t => t.Comments)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ForumThread> CreateThreadAsync(string title, Guid userId)
        {
            var user = _context.UsersInfo.Where(u => u.Id == userId).FirstOrDefault();
            var thread = new ForumThread
            {
                Title = title,
                CreatedAt = DateTime.UtcNow,
                Creator = user.Username
            };

            _context.ForumThread.Add(thread);

            _context.SaveChanges();

            return thread;
        }

        public async Task<Comment> CreateCommentAsync(int id, string content, Guid userId)
        {
            var user = _context.UsersInfo.Where(u => u.Id == userId).FirstOrDefault();
            var comment = new Comment
            {
                Content = content,
                CreatedAt = DateTime.UtcNow,
                Creator = user.Username,
                ForumThreadId = id
            };

            _context.Comment.Add(comment);

            _context.SaveChanges();

            return comment;
        }
    }
}
