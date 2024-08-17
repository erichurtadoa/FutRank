using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Mappers
{
    public class ForumMapper
    {
        public ForumThreadDto MapThreadtoDto(ForumThread entity) {
            return new ForumThreadDto
            {
                Id = entity.Id,
                Title = entity.Title,
                CreatedAt = entity.CreatedAt,
                Creator = entity.Creator,
                CommentsCount = entity.Comments == null? 0 : entity.Comments.Count(),
                Comments = entity.Comments?.Select(c => MapCommenttoDto(c)).ToArray()
            };
        }

        public ForumThreadDto MapThreadtoDetailsDto(ForumThread entity)
        {
            return new ForumThreadDto
            {
                Id = entity.Id,
                Title = entity.Title,
                CreatedAt = entity.CreatedAt,
                Creator = entity.Creator,
                Comments = entity.Comments?.Select(c => MapCommenttoDto(c)).ToArray()
            };
        }

        public CommentDto MapCommenttoDto(Comment entity)
        {
            return new CommentDto
            {
                Id = entity.Id,
                ForumThreadId = entity.ForumThreadId,
                Creator = entity.Creator,
                Content = entity.Content,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
