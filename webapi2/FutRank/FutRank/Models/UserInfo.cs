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
        public string Name { get; set; }
        public string DateSignUp { get; set; }
        public long FixtureTime { get; set; }
        public int FavouriteClubId {  get; set; }
        public virtual ICollection<UserClubs> UserClubs { get; set; }
        public virtual ICollection<UserFixtures> UserFixtures { get; set; }

        public Club FavouriteClub { get; set; }
    }
}
