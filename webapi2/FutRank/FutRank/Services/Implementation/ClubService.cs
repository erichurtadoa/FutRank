using FutRank.Dtos;
using FutRank.Mappers;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;

namespace FutRank.Services.Implementation
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly ClubMapper _mapper;

        public ClubService(IClubRepository clubRepository, ClubMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClubDto> GetClubsAsync()
        {
            var clubs = _clubRepository.GetClubsAsync();
            return clubs.Select(c => _mapper.MapClubtoDto(c));

        }
    }
}
