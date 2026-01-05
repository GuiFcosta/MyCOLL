namespace MyCOLL.Shared.Models.Dto;

public class OrderCreateDto
{
    public List<OrderItemDto> Items { get; set; } = new();
}

public class OrderItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? ProductImage { get; set; }
}