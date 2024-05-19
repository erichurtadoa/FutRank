using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int Capacity { get; set; }
        public string? Surface { get; set; }
        public string Image { get; set; }

        [ForeignKey("Country")]
        public string CountryName { get; set; }
        public Country Country { get; set; }
    }
}
