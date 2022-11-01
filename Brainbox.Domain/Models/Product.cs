using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brainbox.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
        
        [Required]
        [ForeignKey("ProductCategoryId")]
        public int ProductCategoryId { get; set; }
        
        //public ProductCategory ProductCategory { get; set; }

        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
