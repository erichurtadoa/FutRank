using FutRank.Models;

namespace FutRank.Dtos
{
    public class ClubDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Founded { get; set; }
        public bool National { get; set; }
        public string? Logo { get; set; }
        public float? Popularity { get; set; }
        public string? Country { get; set; }
        public string? Flag { get; set; }
        public int Venue { get; set; }
        public string? City { get; set; }
    }
}
