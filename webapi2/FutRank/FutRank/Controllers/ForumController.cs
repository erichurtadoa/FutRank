using FutRank.Dtos;
using FutRank.Models;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FutRank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet("threads")]
        public async Task <IEnumerable<ForumThreadDto>> GetThreads()
        {
            return await _forumService.GetForumAsync();
        }

        [HttpGet("threads/{id}")]
        public async Task<ForumThreadDto> GetThread(int id)
        {
            return await _forumService.GetThreadByIdAsync(id);
        }

        [HttpPost("threads")]
        [Authorize]
        public async Task<ForumThreadDto> CreateThread([FromBody] string title)
        {
            if (User.FindFirstValue(ClaimTypes.Sid) != null)
            {
                var userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
                var thread = await _forumService.CreateThreadAsync(title, userId);

                return thread;
            }
            throw new Exception();
        }

        [HttpPost("threads/{id}/comments")]
        [Authorize]
        public async Task<CommentDto> CreateComment(int id, [FromBody] string content)
        {
            if (User.FindFirstValue(ClaimTypes.Sid) != null)
            {
                var userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
                var comment = await _forumService.CreateCommentAsync(id, content, userId);

                return comment;
            }
            throw new Exception();
        }
    }
}