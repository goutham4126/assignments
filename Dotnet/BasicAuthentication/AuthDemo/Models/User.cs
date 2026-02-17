using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }

        [Required]
        public string firstName { get; set; }

        public string lastName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public bool isActive { get; set; } = true;

        public DateTime createdAt { get; set; } = DateTime.Now;

    }
}
