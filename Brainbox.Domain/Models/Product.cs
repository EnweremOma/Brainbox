using System.ComponentModel.DataAnnotations;

namespace Brainbox.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
