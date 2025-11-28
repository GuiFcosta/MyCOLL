using System.ComponentModel.DataAnnotations;
using MyCOLL.Admin.Models.Entities;

namespace MyCOLL.Admin.Models.DTO.ProductDTO;

public class ProductUpdateDto
{
    [Required]
    public int Id { get; set; }

    [Required, StringLength(60)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [Required]
    public ProductType ProductType { get; set; }

    [Required]
    public AvailabilityMode AvailabilityMode { get; set; }

    [Required]
    public bool IsUsed { get; set; }

    // Campos Sensíveis (Dependem da Role no Controller)
    
    [Range(0.01, double.MaxValue)]
    public decimal BasePrice { get; set; } // Fornecedor pode mudar
    
    [Range(0, 100)]
    public decimal SellTax { get; set; } // Apenas Admin/Funcionário deve conseguir alterar isto [cite: 177]

    public bool IsActive { get; set; } // Apenas Admin/Funcionário deve conseguir alterar isto [cite: 170]
    
    [Required]
    public int CategoryId { get; set; }
}