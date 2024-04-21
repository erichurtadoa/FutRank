using FutRank.Models;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;

namespace FutRank.Services.Implementation
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;

        public ClubService(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public IEnumerable<Club> GetClubsAsync()
        {
            return _clubRepository.GetClubsAsync();
        }
    }
}
