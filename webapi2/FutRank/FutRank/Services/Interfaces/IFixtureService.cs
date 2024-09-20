using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Services.Interfaces
{
    public interface IFixtureService
    {
        Task<IEnumerable<FixtureDto>> GetFixturesAsync(FixtureFilter filter);
        Task<IEnumerable<FixtureDto>> GetFixturesUserAsync(Guid userId, FixtureFilter filter);
        Task<IEnumerable<FixtureDto>> GetOnlyFixturesUserAsync(Guid userId);
        Task<FixtureDetailsDto> GetFixtureByIdAsync(int id, Guid userId);
        Task VoteFixture(int vote, Guid userId, int fixtureId);
        Task<CommentFixtureDto> CreateCommentAsync(int id, string content, Guid userId);
    }
}
