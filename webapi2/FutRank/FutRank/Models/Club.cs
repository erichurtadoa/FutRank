using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Founded { get; set; }
        public bool National { get; set; }
        public string Logo { get; set; }
        public float? Popularity {  get; set; }

        [ForeignKey("Country")]
        public string CountryName { get; set; }
        public Country Country { get; set; }

        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public virtual ICollection<Standing> Standings { get; set; }
    }
}
