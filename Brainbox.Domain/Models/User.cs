using System.ComponentModel.DataAnnotations;

namespace Brainbox.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
