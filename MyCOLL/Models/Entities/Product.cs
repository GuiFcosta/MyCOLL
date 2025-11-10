using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyCOLL.Models.Entities;

public enum State
{
    Inactive, Active
}

public enum Condition
{
    New, Used, Refurbished
}
public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required, StringLength(30)]
    public string Name { get; set; } = string.Empty;
    
    [Required, StringLength(100)]
    public string Description { get; set; } = string.Empty;
    
    [Required, Precision(18,2)]
    public decimal BasePrice { get; set; }
    
    [Required, Range(0, 100), Precision(5,2)]
    public decimal SellTax { get; set; }
    
    [Required]
    public decimal FinalPrice => BasePrice + (BasePrice * SellTax / 100);
    
    [Required]
    public Condition Condition { get; set; } = Condition.New;
    
    [Required]
    public State State { get; set; } = State.Inactive;

    public ICollection<Category>? Categories { get; set; }
}