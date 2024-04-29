using FutRank.Models;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FutRank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet("All")]
        public IEnumerable<Venue> Get()
        {
            return _venueService.GetVenuesAsync();
        }
    }
}