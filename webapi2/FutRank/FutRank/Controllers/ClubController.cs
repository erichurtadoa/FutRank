using FutRank.Dtos;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FutRank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        private readonly UserManager<IdentityUser> _userManager;

        public ClubController(IClubService clubService, UserManager<IdentityUser> userManager)
        {
            _clubService = clubService;
            _userManager = userManager;
        }

        [HttpGet("All")]
        public IEnumerable<ClubDto> GetClubs()
        {
            return _clubService.GetClubsAsync();
        }

        /*[HttpGet("AllWithVoteStatus")]
        [Authorize]
        public async Task<IActionResult> GetClubsWithVoteStatus()
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);
            var userGuid = new Guid(userId);

            var clubs = await _context.Clubs
                .Select(c => new ClubWithVoteStatusDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    Founded = c.Founded,
                    National = c.National,
                    Logo = c.Logo,
                    Popularity = c.Popularity,
                    UpVote = _context.UserClubs
                        .Where(uc => uc.ClubId == c.Id && uc.UserId == userGuid)
                        .Select(uc => uc.UpVote)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return Ok(clubs);
        }*/

        [HttpGet("{id}")]
        public ClubDetailsDto GetClubById(int id)
        {
            return _clubService.GetClubByIdAsync(id);
        }

        [HttpPost("Vote")]
        [Authorize]
        public async Task<IActionResult> VoteClub([FromBody] bool upVote, int clubId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);
            var user = _userManager.FindByIdAsync(userId);

            var userGuid = new Guid(userId);

            await _clubService.VoteClub(upVote, userGuid, clubId);

            return Ok();
        }
    }
}
