﻿using FutRank.Dtos;
using FutRank.Models;
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
        public IEnumerable<ClubDto> GetClubs([FromQuery] ClubFilter filter)
        {
            if (User.FindFirstValue(ClaimTypes.Sid) != null)
            {
                var userGuid = new Guid(User.FindFirstValue(ClaimTypes.Sid));
                return _clubService.GetClubsUserAsync(userGuid, filter);
            }
            return _clubService.GetClubsAsync(filter);
        }

        [HttpGet("UserClubs/{userId}")]
        public async Task<IEnumerable<ClubDto>> GetUserClubs(Guid userId)
        {
            return await _clubService.GetOnlyClubsUserAsync(userId);
        }

        [HttpGet("{id}")]
        public ClubDetailsDto GetClubById(int id)
        {
            var userGuid = User.FindFirstValue(ClaimTypes.Sid) != null ? new Guid(User.FindFirstValue(ClaimTypes.Sid)) : new Guid();
            return _clubService.GetClubByIdAsync(id, userGuid);
        }

        [HttpPost("Vote")]
        [Authorize]
        public async Task<IActionResult> VoteClub([FromBody] bool upVote, int clubId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);

            var userGuid = new Guid(userId);

            await _clubService.VoteClub(upVote, userGuid, clubId);

            return Ok();
        }

        [HttpPost("AddFavourite")]
        [Authorize]
        public async Task<IActionResult> AddFavourite(int clubId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);

            var userGuid = new Guid(userId);

            await _clubService.AddFavourite(userGuid, clubId);

            return Ok();
        }
    }
}
