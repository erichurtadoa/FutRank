using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class ClubFilter
    {
        public string? Team { get; set; }
        public string? Country { get; set; }
    }
}
