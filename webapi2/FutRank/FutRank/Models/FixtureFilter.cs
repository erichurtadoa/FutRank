using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class FixtureFilter
    {
        public string? Team { get; set; }
        public string? League { get; set; }
        public string? Season {  get; set; }
    }
}
