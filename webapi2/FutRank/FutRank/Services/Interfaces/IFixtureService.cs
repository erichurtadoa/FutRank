using FutRank.Dtos;

namespace FutRank.Services.Interfaces
{
    public interface IFixtureService
    {
        IEnumerable<FixtureDto> GetFixturesAsync();
        IEnumerable<FixtureDto> GetFixturesUserAsync(Guid userId);
        Task VoteFixture(int vote, Guid userId, int fixtureId);
    }
}
