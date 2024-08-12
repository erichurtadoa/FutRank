using FutRank.Models;

namespace FutRank.Dtos
{
    public class StandingDto
    {
        public string Competition { get; set; }
        public string Season { get; set; }
        public int? Rank { get; set; }
    }
}
