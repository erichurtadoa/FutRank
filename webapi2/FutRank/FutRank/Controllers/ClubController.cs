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
        public IEnumerable<Club> GetClubs()
        {
            return _clubService.GetClubsAsync();
        }

        [HttpPost("League")]
        public IActionResult ProcessLeague([FromBody] LeagueRequest leagueRequest)
        {
            try
            {
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

        public class LeagueRequest
        {
            public LeagueData League { get; set; }
            public Country Country { get; set; }
            public List<SeasonData> Seasons { get; set; }
        }

        public class LeagueData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Logo { get; set; }
        }

        public class SeasonData
        {
            public int Year { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
        }
    }
}
