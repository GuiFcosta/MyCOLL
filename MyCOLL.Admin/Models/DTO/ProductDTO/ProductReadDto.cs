namespace MyCOLL.Admin.Models.DTO.ProductDTO;

public class ProductReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }
    
    public string ProductType { get; set; } = string.Empty;      // Convertido de Enum para String
    public string AvailabilityMode { get; set; } = string.Empty; // Convertido de Enum para String
    
    public bool IsUsed { get; set; }
    public bool IsActive { get; set; } // Importante para o Admin saber se está visível

    // Preços
    public decimal BasePrice { get; set; }
    public decimal SellTax { get; set; }
    public decimal FinalPrice { get; set; } // O valor calculado vindo da Entidade

    // Dados Relacionados (Flattened)
    public string SupplierId { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty; // Útil para mostrar quem vende
    
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    // Lista simplificada de imagens (apenas URLs ou DTO leve)
    public ICollection<ProductImageDto> Images { get; set; } = new List<ProductImageDto>();
}

// DTO auxiliar para imagens
public class ProductImageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsMain { get; set; }
}