using FutRank.Dtos;
using FutRank.Mappers;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;

namespace FutRank.Services.Implementation
{
    public class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private readonly ForumMapper _mapper;

        public ForumService(IForumRepository forumRepository, ForumMapper mapper)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ForumThreadDto>> GetForumAsync()
        {
            var forum = await _forumRepository.GetForumAsync();
            return forum.Select(c => _mapper.MapThreadtoDto(c));
        }

        public async Task<ForumThreadDto> GetThreadByIdAsync(int id)
        {
            var thread = await _forumRepository.GetThreadById(id);
            return _mapper.MapThreadtoDetailsDto(thread);
        }

        public async Task<ForumThreadDto> CreateThreadAsync(string title, Guid userId)
        {
            var thread = await _forumRepository.CreateThreadAsync(title, userId);
            return _mapper.MapThreadtoDetailsDto(thread);
        }

        public async Task<CommentDto> CreateCommentAsync(int id, string content, Guid userId)
        {
            var comment = await _forumRepository.CreateCommentAsync(id, content, userId);
            return _mapper.MapCommenttoDto(comment);
        }
    }
}
