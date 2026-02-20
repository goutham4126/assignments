using System.ComponentModel.DataAnnotations;

namespace RBADemo.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required] public string Username { get; set; } = null!;
        [Required] public string PasswordHash { get; set; } = null!;
        [Required] public string Role { get; set; } = "Customer"; // e.g. "Admin", "Manager", "Customer"
    }
}
