using System.ComponentModel.DataAnnotations;

namespace MyCOLL.Admin.Models.DTO.CategoryDTO;

public class CategoryCreateDto
{
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
}