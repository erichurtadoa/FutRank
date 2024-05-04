using FutRank.Dtos;

namespace FutRank.Services.Interfaces
{
    public interface IFixtureService
    {
        IEnumerable<FixtureDto> GetFixturesAsync();
    }
}
