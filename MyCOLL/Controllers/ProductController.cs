using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCOLL.Data;
using MyCOLL.Models.DTO.ProductDTO;
using MyCOLL.Models.Entities;

namespace MyCOLL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _dbcontext;
    private readonly IMapper _mapper;
    
    public ProductController(ApplicationDbContext dbcontext, IMapper mapper)
    {
        _dbcontext = dbcontext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _dbcontext.Products
            .Include(p => p.Categories)
            .ToListAsync();
        var dtoList = _mapper.Map<IEnumerable<ProductReadDto>>(products);
        return Ok(dtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _dbcontext.Products.FindAsync(id);
        if (product == null)
            return NotFound();
        var dto = _mapper.Map<ProductReadDto>(product);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(ProductCreateDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        
        if (dto.CategoryIds != null && dto.CategoryIds.Any())
        {
            var categories = await _dbcontext.Categories
                .Where(c => dto.CategoryIds.Contains(c.Id))
                .ToListAsync();

            product.Categories = categories;
        }
        
        _dbcontext.Products.Add(product);
        await _dbcontext.SaveChangesAsync();
        
        var createdDto = _mapper.Map<ProductReadDto>(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, createdDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto dto)
    {
        var product = await _dbcontext.Products.FindAsync(id);
        if(product == null)
            return NotFound();
        
        _mapper.Map(dto, product);
        await _dbcontext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _dbcontext.Products.FindAsync(id);
        if (product == null)
            return NotFound();
        _dbcontext.Products.Remove(product);
        await _dbcontext.SaveChangesAsync();
        return NoContent();
    }
}