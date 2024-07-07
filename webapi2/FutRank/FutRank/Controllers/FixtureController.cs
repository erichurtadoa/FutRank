using FutRank.Dtos;
using FutRank.Models;
using FutRank.Services.Implementation;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace FutRank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FixtureController : ControllerBase
    {
        private readonly IFixtureService _fixtureService;
        private readonly UserManager<IdentityUser> _userManager;

        public FixtureController(IFixtureService fixtureService, UserManager<IdentityUser> userManager)
        {
            _fixtureService = fixtureService;
            _userManager = userManager;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<FixtureDto>> GetFixtures()
        {
            if (User.FindFirstValue(ClaimTypes.Sid) != null)
            {
                var userGuid = new Guid(User.FindFirstValue(ClaimTypes.Sid));
                return await _fixtureService.GetFixturesUserAsync(userGuid);
            }
            return await _fixtureService.GetFixturesAsync();
        }

        [HttpPost("Vote")]
        [Authorize]
        public async Task<IActionResult> VoteFixture([FromBody] int vote, int fixtureId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);
            var user = _userManager.FindByIdAsync(userId);

            var userGuid = new Guid(userId);

            await _fixtureService.VoteFixture(vote, userGuid, fixtureId);

            return Ok();
        }

        [HttpPost("ConvertJson")]
        public IActionResult ProcessLeague([FromBody] Requestdto[] leagueRequest)
        {
            if (leagueRequest == null || !leagueRequest.Any())
            {
                return BadRequest("No hay datos proporcionados para procesar.");
            }

            var processedFixtures = new List<ProcessedFixture>();

            foreach (var fixture in leagueRequest)
            {
                var processedFixture = new ProcessedFixture
                {
                    Id = fixture.Fixture.Id,
                    Referee = fixture.Fixture.Referee,
                    Date = fixture.Fixture.Date,
                    VenueId = fixture.Fixture.Venue.Id,
                    LeagueId = fixture.League.Id,
                    Season = fixture.League.Season?.ToString(),
                    Round = fixture.League.Round,
                    HomeTeamId = fixture.Teams.Home.Id,
                    AwayTeamId = fixture.Teams.Away.Id,
                    GoalsHome = fixture.Goals?.Home,
                    GoalsAway = fixture.Goals?.Away,
                    PenaltyHome = fixture.Score?.Penalty?.Home,
                    PenaltyAway = fixture.Score?.Penalty?.Away
                };

                processedFixtures.Add(processedFixture);
            }

            return Ok(processedFixtures);
        }
    }

    public class ProcessedFixture
    {
        public int Id { get; set; }
        public string? Referee { get; set; }
        public string Date { get; set; }
        public int VenueId { get; set; }
        public int LeagueId { get; set; }
        public string? Season { get; set; }
        public string Round { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? GoalsHome { get; set; }
        public int? GoalsAway { get; set; }
        public int? PenaltyHome { get; set; }
        public int? PenaltyAway { get; set; }
    }

    public class Requestdto
    {
        public Fixturedto Fixture { get; set; }
        public Leaguedto League { get; set; }
        public Teamsdto Teams { get; set; }
        public Goal Goals { get; set; }
        public Scores Score { get; set; }
    }

    public class Fixturedto
    {
        public int Id { get; set; }
        public string? Referee { get; set; }
        public string Timezone { get; set; }
        public string Date { get; set; }
        public long Timestamp { get; set; }
        public Periods Periods { get; set; }
        public Venuedto Venue { get; set; }
        public Status Status { get; set; }
    }

    public class Periods
    {
        public long? First { get; set; }
        public long? Second { get; set; }
    }

    public class Venuedto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class Status
    {
        public string Long { get; set; }
        public string Short { get; set; }
        public int? Elapsed { get; set; }
    }

    public class Leaguedto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Logo { get; set; }
        public string Flag { get; set; }
        public int? Season { get; set; }
        public string Round { get; set; }
    }

    public class Teamsdto
    {
        public Team Home { get; set; }
        public Team Away { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool? Winner { get; set; }
    }

    public class Goal
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
    }

    public class Scores
    {
        public Goal Halftime { get; set; }
        public Goal Fulltime { get; set; }
        public Goal Extratime { get; set; }
        public Goal Penalty { get; set; }
    }
}
