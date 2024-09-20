using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class Fixture
    {
        [Key]
        public int Id { get; set; }
        public string? Referee { get; set; }
        public string Date { get; set; }
        public int VenueId { get; set; }
        public int LeagueId { get; set; }
        public string? Season { get; set; }
        public string? Round {  get; set; }
        public int HomeTeamId {  get; set; }
        public int AwayTeamId { get; set; }
        public int? GoalsHome { get; set; }
        public int? GoalsAway { get; set; }
        public int? PenaltyHome { get; set; }
        public int? PenaltyAway { get; set; }
        public float? Rate { get; set; }
        public int Time { get; set; }

        public League League { get; set; }
        public Venue Venue { get; set; }
        public Club HomeClub { get; set; }
        public Club AwayClub { get; set; }

        public virtual ICollection<UserFixtures> UserFixtures { get; set; }
        public ICollection<CommentFixture> Comments { get; set; }
    }
}
