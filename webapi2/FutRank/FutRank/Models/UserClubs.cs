using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class UserClubs
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public int ClubId { get; set; }
        public bool? UpVote {  get; set; }
        public bool Favourite { get; set; }

        [ForeignKey("ClubId")]
        public virtual Club Club { get; set; }

        [ForeignKey("UserId")]
        public virtual UserInfo User { get; set; }
    }
}
