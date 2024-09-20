using FutRank.Controllers;
using FutRank.Dtos;
using FutRank.Mappers;
using FutRank.Models;
using FutRank.Repositories.Implementation;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;

namespace FutRank.Services.Implementation
{
    public class FixtureService : IFixtureService
    {
        private readonly IFixtureRepository _fixtureRepository;
        private readonly FixtureMapper _mapper;
        private readonly IUserRepository _userRepository;

        public FixtureService(IFixtureRepository fixtureRepository, FixtureMapper mapper, IUserRepository userRepository)
        {
            _fixtureRepository = fixtureRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<FixtureDto>> GetFixturesAsync(FixtureFilter filter)
        {
            var fixtures = await _fixtureRepository.GetFixturesAsync(filter);
            var fixtureDto = fixtures.Select(c => _mapper.MapFixturetoDto(c));
            return fixtureDto.OrderByDescending(u => u.Rate);
        }

        public async Task<IEnumerable<FixtureDto>> GetFixturesUserAsync(Guid userId, FixtureFilter filter)
        {
            var fixtures = await _fixtureRepository.GetFixturesAsync(filter);
            var fixtureDto = fixtures.Select(c => _mapper.MapFixturetoDtoUser(c, userId));
            return fixtureDto.OrderByDescending(u => u.Rate);
        }

        public async Task<IEnumerable<FixtureDto>> GetOnlyFixturesUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserDetailsAsync(userId);
            var userFixtures = user.UserFixtures.Select(x => x.Fixture);
            var userFIxturesDto = userFixtures.Select(c => _mapper.MapFixturetoDtoUser(c, userId));
            return userFIxturesDto.OrderByDescending(u => u.UserNote);
        }

        public async Task<FixtureDetailsDto> GetFixtureByIdAsync(int id, Guid userId)
        {
            var fixture = await _fixtureRepository.GetFixtureByIdAsync(id);
            return _mapper.MapFixturetoDetailsDto(fixture, userId);
        }

        public async Task VoteFixture(int vote, Guid userId, int fixtureId)
        {
            var userFixture = new UserFixtures
            {
                UserId = userId,
                FixtureId = fixtureId,
                UserNote = vote == -1 ? null : vote,
            };
            await _fixtureRepository.VoteFixtureAsync(userFixture);

            await _fixtureRepository.UpdateFixtureNoteAsync(fixtureId);
        }

        public async Task<CommentFixtureDto> CreateCommentAsync(int id, string content, Guid userId)
        {
            var comment = await _fixtureRepository.CreateCommentAsync(id, content, userId);
            return _mapper.MapCommentFixturetoDto(comment);
        }
    }
}
