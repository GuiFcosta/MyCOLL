using System.ComponentModel.DataAnnotations;
using MyCOLL.Api.Models.Entities;

namespace MyCOLL.Api.Models.DTO.ProductDTO;

public class ProductUpdateDto
{
    [Required, StringLength(30)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal BasePrice { get; set; }

    [Required, Range(0, 100)]
    public decimal SellTax { get; set; }

    [Required]
    public Condition Condition { get; set; }

    [Required]
    public State State { get; set; }
    
    [Required]
    public ICollection<int>? CategoryIds { get; set; }
}