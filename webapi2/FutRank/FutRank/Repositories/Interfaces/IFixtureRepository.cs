using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IFixtureRepository
    {
        Task<IEnumerable<Fixture>> GetFixturesAsync(FixtureFilter filter);
        Task<Fixture> GetFixtureByIdAsync(int id);
        Task VoteFixtureAsync(UserFixtures userFixtures);
        Task UpdateFixtureNoteAsync(int fixtureId);
    }
}
