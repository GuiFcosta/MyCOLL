using System.ComponentModel.DataAnnotations;
using MyCOLL.Admin.Models.Entities;

namespace MyCOLL.Admin.Models.DTO.ProductDTO;

public class ProductCreateDto
{
    [Required(ErrorMessage = "The name is required")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 60 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "The description is required")]
    [StringLength(500, ErrorMessage = "The description cannot exceed 500 characters")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "The stock cannot be negative")]
    public int Stock { get; set; }

    [Required]
    public ProductType ProductType { get; set; }

    [Required]
    public AvailabilityMode AvailabilityMode { get; set; }

    [Required]
    public bool IsUsed { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "The base price must be greater than zero")]
    public decimal BasePrice { get; set; }

    [Required(ErrorMessage = "The supplier ID is required")]
    public int CategoryId { get; set; }
}