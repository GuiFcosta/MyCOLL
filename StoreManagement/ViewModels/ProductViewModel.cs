using System.ComponentModel.DataAnnotations;
namespace StoreManagement.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }
    
    [Range(0.01, double.MaxValue, ErrorMessage = "Base Price must be greater than zero")]
    public decimal BasePrice { get; set; }
    
    [Range(0, 100, ErrorMessage = "Sell Tax must be between 0 and 100")]
    public decimal SellTax { get; set; }
    
    [Required(ErrorMessage = "Condition is required")]
    public string? Condition { get; set; }
    
    [Required(ErrorMessage =  "State is required")]
    public string? State { get; set; }
    
    [Required(ErrorMessage = "Condition is required")]
    public int CategoryId { get; set; }
}
