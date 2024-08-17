using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ForumThreadId { get; set; }
        public string Creator { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public ForumThread ForumThread { get; set; }
    }
}
