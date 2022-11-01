using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Brainbox.Domain.Models;

public class Cart
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public int Count { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]

    public User User { get; set; }

}






