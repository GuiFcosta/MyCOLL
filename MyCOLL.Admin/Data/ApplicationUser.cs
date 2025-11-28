using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using MyCOLL.Admin.Models.Entities;

namespace MyCOLL.Admin.Data;

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
    public string Nif { get; set; } = string.Empty;
    
    [Required, StringLength(100)]
    public string Address { get; set; } = string.Empty;
    
    [Required]
    public StateAccount StateAccount { get; set; } = StateAccount.Pending;
    
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Product>? Products { get; set; }
}