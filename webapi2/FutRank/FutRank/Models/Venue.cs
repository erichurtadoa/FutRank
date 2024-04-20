using System.ComponentModel.DataAnnotations;

namespace FutRank.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string Country { get; set; }
        public int Capacity { get; set; }
        public string? Surface { get; set; }
        public string Image { get; set; }
    }
}
