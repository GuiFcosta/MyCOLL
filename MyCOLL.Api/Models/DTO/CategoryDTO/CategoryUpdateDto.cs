using System.ComponentModel.DataAnnotations;

namespace MyCOLL.Api.Models.DTO.CategoryDTO;

public class CategoryUpdateDto
{
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
}