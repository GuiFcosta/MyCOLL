namespace MyCOLL.Shared.Models.Dto;

public class SupplierSaleDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? ProductImage { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalLine => Quantity * UnitPrice; // Total desta linha
    public string Status { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
}