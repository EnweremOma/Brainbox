using System.ComponentModel.DataAnnotations;

namespace Brainbox.Domain.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
