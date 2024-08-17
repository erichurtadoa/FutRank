namespace FutRank.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int ForumThreadId { get; set; }
        public string Creator { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
