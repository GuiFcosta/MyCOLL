using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using MyCOLL.Data.Models.Entities;

namespace MyCOLL.Data.Data;
public enum StateAccount
{
    Active,
    Pending,
    Suspended
}

public class ApplicationUser : IdentityUser
{
    [Required, StringLength(50)]
    public string FullName { get; set; } = string.Empty;
    
    [Required, StringLength(9)]
    public string? Nif { get; set; }
    
    [Required, StringLength(100)]
    public string? Address { get; set; }
    
    [Required]
    public StateAccount StateAccount { get; set; } = StateAccount.Pending;
    
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Product>? Products { get; set; }
}