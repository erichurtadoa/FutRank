using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class CommentFixture
    {
        public int Id { get; set; }
        public int FixtureId { get; set; }
        public string Creator { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Fixture Fixture { get; set; }
    }
}
