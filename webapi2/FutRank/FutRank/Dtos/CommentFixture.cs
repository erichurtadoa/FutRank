namespace FutRank.Dtos
{
    public class CommentFixtureDto
    {
        public int Id { get; set; }
        public int FixtureId { get; set; }
        public string Creator { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
