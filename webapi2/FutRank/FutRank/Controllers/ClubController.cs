using FutRank.Dtos;
using FutRank.Models;
using FutRank.Services.Implementation;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
    }
}
