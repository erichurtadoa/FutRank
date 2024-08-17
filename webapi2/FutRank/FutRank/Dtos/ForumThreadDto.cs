using FutRank.Models;

namespace FutRank.Dtos
{
    public class ForumThreadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommentsCount { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
