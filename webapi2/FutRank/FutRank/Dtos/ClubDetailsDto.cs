namespace FutRank.Dtos
{
    public class ClubDetailsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Founded { get; set; }
        public bool National { get; set; }
        public string? Logo { get; set; }
        public float? Popularity { get; set; }
        public string? Country { get; set; }
        public string? flag { get; set; }
        public string? VenueName { get; set; }
        public string? VenueAddress { get; set; }
        public int VenueCapacity { get; set; }
        public string? VenueSurface { get; set; }
        public string? VenueImage { get; set; }
        public string? VenueCity { get; set; }
    }
}
