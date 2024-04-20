using FutRank.Models;
using FutRank.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FutRank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IVenueRepository _venueRepository;
        private readonly IClubRepository _clubRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IVenueRepository venueRepository, IClubRepository clubRepository)
        {
            _logger = logger;
            _venueRepository = venueRepository;
            _clubRepository = clubRepository;
        }

        [HttpGet("WeatherForecast")]
        public IEnumerable<Venue> Get()
        {
            return _venueRepository.GetVenuesAsync();
        }

        [HttpGet("Clubs")]
        public IEnumerable<Club> GetClubs()
        {
            return _clubRepository.GetClubsAsync();
        }
    }
}