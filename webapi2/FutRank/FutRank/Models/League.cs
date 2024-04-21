using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class League
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Logo { get; set; }
        [Key]
        public string SeasonYear { get; set; }
        public string SeasonStart { get; set;}
        public string SeasonEnd { get; set;}

        [ForeignKey("Country")]
        public string CountryName { get; set; }
        public Country Country { get; set; }
    }
}
