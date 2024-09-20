using FutRank.Models;

namespace FutRank.Dtos
{
    public class FixtureDetailsDto
    {
        public int Id { get; set; }
        public string? Referee { get; set; }
        public string Date { get; set; }
        public string VenueName { get; set; }
        public string VenueImage { get; set; }
        public string League { get; set; }
        public string? Season { get; set; }
        public string Round { get; set; }
        public string HomeTeamName { get; set; }
        public string LogoHome { get; set; }
        public string LogoAway { get; set; }
        public string AwayTeamName { get; set; }
        public int? GoalsHome { get; set; }
        public int? GoalsAway { get; set; }
        public int? PenaltyHome { get; set; }
        public int? PenaltyAway { get; set; }
        public float? Rate { get; set; }
        public int? UserNote { get; set; }
        public ICollection<CommentFixtureDto> Comments { get; set; }
    }
}
