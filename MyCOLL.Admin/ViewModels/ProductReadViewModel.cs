namespace MyCOLL.Admin.ViewModels;

public class ProductReadViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public decimal SellTax { get; set; }
    public decimal FinalPrice { get; set; }
    public string Condition { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public ICollection<string> CategoryNames { get; set; } = new List<string>();
}
