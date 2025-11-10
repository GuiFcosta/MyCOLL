using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCOLL.Data;
using MyCOLL.Models.DTO.CategoryDTO;
using MyCOLL.Models.Entities;

namespace MyCOLL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _dbcontext;
    private readonly IMapper _mapper;
    
    public CategoryController(ApplicationDbContext dbcontext, IMapper mapper)
    {
        _dbcontext = dbcontext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetCategories()
    {
        var categories = await _dbcontext.Categories
            .Include(c => c.Products)
            .ToListAsync();
        
        var dtoList = _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
        return Ok(dtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _dbcontext.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
            return NotFound();

        var dto = _mapper.Map<CategoryReadDto>(category);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory(CategoryCreateDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        _dbcontext.Categories.Add(category);
        await _dbcontext.SaveChangesAsync();
        
        var createdDto = _mapper.Map<CategoryReadDto>(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, createdDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryUpdateDto dto)
    {
        var category = await _dbcontext.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        _mapper.Map(dto, category);
        await _dbcontext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _dbcontext.Categories.FindAsync(id);
        if (category == null)
            return NotFound();
        _dbcontext.Categories.Remove(category);
        await _dbcontext.SaveChangesAsync();
        return NoContent();
    }
}