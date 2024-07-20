using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IFixtureRepository
    {
        Task<IEnumerable<Fixture>> GetFixturesAsync(FixtureFilter filter);
        Task VoteFixtureAsync(UserFixtures userFixtures);
        Task UpdateFixtureNoteAsync(int fixtureId);
    }
}
