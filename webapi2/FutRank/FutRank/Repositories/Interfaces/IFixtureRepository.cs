using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IFixtureRepository
    {
        Task<IEnumerable<Fixture>> GetFixturesAsync();
        Task VoteFixtureAsync(UserFixtures userFixtures);
        Task UpdateFixtureNoteAsync(int fixtureId);
    }
}
