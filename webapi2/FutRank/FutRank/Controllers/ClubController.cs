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

        [HttpGet("Clubs")]
        public IEnumerable<ClubDto> GetClubs()
        {
            return _clubService.GetClubsAsync();
        }

        [HttpPost("League")]
        public IActionResult ProcessLeague([FromBody] Fixture[] leagueRequest)
        {
            try
            {
                var processed = new List<Fixture>();
                processed = leagueRequest.ToList();

                processed.Select(x =>
                {

                });

                // Deserialize the incoming JSON
                var league = leagueRequest.League;
                var leagueObject = new LeagueData
                {
                    Id = league.Id,
                    Name = league.Name,
                    Type = league.Type,
                    Logo = league.Logo
                };

                // Extract country data
                var country = leagueRequest.Country;
                var countryObject = new Country
                {
                    Name = country.Name,
                    Code = country.Code,
                    Image = country.Image
                };

                // Extract season data
                var season = leagueRequest.Seasons.FirstOrDefault();
                var seasonObject = new SeasonData
                {
                    Year = season.Year,
                    Start = season.Start,
                    End = season.End
                };

                // Generate the response JSON
                var responseData = new
                {
                    id = leagueObject.Id,
                    name = leagueObject.Name,
                    type = leagueObject.Type,
                    logo = leagueObject.Logo,
                    countryName = countryObject.Name,
                    seasonYear = seasonObject.Year,
                    seasonStart = seasonObject.Start,
                    seasonEnd = seasonObject.End
                };

                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        public class Fixture
        {
            public int Id { get; set; }
            public string Referee { get; set; }
            public string Timezone { get; set; }
            public DateTime Date { get; set; }
            public long Timestamp { get; set; }
            public Periods Periods { get; set; }
            public Venue Venue { get; set; }
            public Status Status { get; set; }
        }

        public class Periods
        {
            public long First { get; set; }
            public long Second { get; set; }
        }

        public class Venue
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
        }

        public class Status
        {
            public string Long { get; set; }
            public string Short { get; set; }
            public int Elapsed { get; set; }
        }

        public class League
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }
            public string Logo { get; set; }
            public string Flag { get; set; }
            public int Season { get; set; }
            public string Round { get; set; }
        }

        public class Teams
        {
            public Team Home { get; set; }
            public Team Away { get; set; }
        }

        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Logo { get; set; }
            public bool Winner { get; set; }
        }

        public class Goals
        {
            public int Home { get; set; }
            public int Away { get; set; }
        }

        public class Score
        {
            public Goals Halftime { get; set; }
            public Goals Fulltime { get; set; }
            public Goals Extratime { get; set; }
            public Goals Penalty { get; set; }
        }
    }
}
