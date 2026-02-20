using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBADemo.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }

        public string CustomerId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}