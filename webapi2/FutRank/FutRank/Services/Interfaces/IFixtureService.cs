using FutRank.Dtos;

namespace FutRank.Services.Interfaces
{
    public interface IFixtureService
    {
        Task<IEnumerable<FixtureDto>> GetFixturesAsync();
        Task<IEnumerable<FixtureDto>> GetFixturesUserAsync(Guid userId);
        Task VoteFixture(int vote, Guid userId, int fixtureId);
    }
}
