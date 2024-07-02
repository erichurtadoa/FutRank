using FutRank.Dtos;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutRank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet("All")]
        public IEnumerable<ClubDto> GetClubs()
        {
            return _clubService.GetClubsAsync();
        }

        [HttpGet("{id}")]
        public ClubDetailsDto GetClubById(int id)
        {
            return _clubService.GetClubByIdAsync(id);
        }

        [HttpPost("Vote")]
        [Authorize]
        public IActionResult VoteClub([FromBody] bool upVote)
        {
            return Ok();
        }
    }
}
