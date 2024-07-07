using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class UserFixtures
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public int FixtureId { get; set; }
        public int? UserNote {  get; set; }

        [ForeignKey("FixtureId")]
        public virtual Fixture Fixture { get; set; }

        [ForeignKey("UserId")]
        public virtual UserInfo User { get; set; }
    }
}
