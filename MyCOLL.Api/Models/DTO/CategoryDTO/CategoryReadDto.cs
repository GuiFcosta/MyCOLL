namespace MyCOLL.Api.Models.DTO.CategoryDTO;

public class CategoryReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<string> Products { get; set; } = new List<string>();
}