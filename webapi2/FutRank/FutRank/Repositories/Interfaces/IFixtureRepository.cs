using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IFixtureRepository
    {
        IEnumerable<Fixture> GetFixturesAsync();
    }
}
