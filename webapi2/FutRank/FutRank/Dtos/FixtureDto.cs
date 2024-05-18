namespace FutRank.Dtos
{
    public class FixtureDto
    {
        public int Id { get; set; }
        public string? Referee { get; set; }
        public string Date { get; set; }
        public int VenueId { get; set; }
        public string League { get; set; }
        public string? Season { get; set; }
        public string Round { get; set; }
        public int HomeTeamId { get; set; }
        public string LogoHome { get; set; }
        public string LogoAway { get; set; }
        public int AwayTeamId { get; set; }
        public int? GoalsHome { get; set; }
        public int? GoalsAway { get; set; }
        public int? PenaltyHome { get; set; }
        public int? PenaltyAway { get; set; }
        public float? Rate { get; set; }
    }
}
