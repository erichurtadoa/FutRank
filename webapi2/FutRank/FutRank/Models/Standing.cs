using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class Standing
    {
        [Key]
        public int LeagueId { get; set; }
        [Key]
        public string Season { get; set; }
        [Key]
        public int ClubId { get; set; }
        public int Rank { get; set; }
        public string Description { get; set; };

        [ForeignKey("LeagueId+Season")]
        public virtual League League { get; set; }

        [ForeignKey("ClubId")]
        public virtual Club Club { get; set; }
    }
}
