using FutRank.Dtos;
using FutRank.Mappers;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;

namespace FutRank.Services.Implementation
{
    public class FixtureService : IFixtureService
    {
        private readonly IFixtureRepository _fixtureRepository;
        private readonly FixtureMapper _mapper;

        public FixtureService(IFixtureRepository fixtureRepository, FixtureMapper mapper)
        {
            _fixtureRepository = fixtureRepository;
            _mapper = mapper;
        }

        public IEnumerable<FixtureDto> GetFixturesAsync()
        {
            var fixtures = _fixtureRepository.GetFixturesAsync();
            return fixtures.Select(c => _mapper.MapFixturetoDto(c));

        }
    }
}
