using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCOLL.Api.Models.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Product>? Products { get; set; }
}