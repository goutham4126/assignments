using System.ComponentModel.DataAnnotations;

namespace RBADemo.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; } 
    }
}
