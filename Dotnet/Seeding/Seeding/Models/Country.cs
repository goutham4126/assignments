using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seeding.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CountryName { get; set; }
        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; }

        public ICollection<State> States { get; set; }
    }
}
