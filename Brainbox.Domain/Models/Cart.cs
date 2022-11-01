using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Brainbox.Domain.Models;

public class Cart
{
    public int Id { get; set; }
   
    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
    
    [Range (1, 10)]
    public int Qty { get; set; }
    
    [ForeignKey("UserId")]
    [ValidateNever]
    public int UserId { get; set; }
    

}






