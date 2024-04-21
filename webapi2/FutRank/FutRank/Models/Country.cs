using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutRank.Models
{
    public class Country
    {
        [Key]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Image {  get; set; }
    }
}
