using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class UserInfo
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserClubs> UserClubs { get; set; }
        public virtual ICollection<UserFixtures> UserFixtures { get; set; }
    }
}
