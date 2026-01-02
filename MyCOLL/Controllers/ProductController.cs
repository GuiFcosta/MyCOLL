using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using MyCOLL.Shared.Constants;
using MyCOLL.Data.Models.Entities;
using MyCOLL.Interface;
using MyCOLL.Shared.Models.Dto;

namespace MyCOLL.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;    
    
    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    // GET: api/products
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        // 1. Busca as Entidades do Banco de Dados
        var productsFromDb = await _repository.GetClientProducts();

        // 2. Transforma (Mapeia) Entidade -> DTO
        var productsDto = productsFromDb.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Stock = p.Stock,
            BasePrice = p.BasePrice,
            FinalPrice = p.FinalPrice, // Valor calculado na Entidade
            IsActive = p.IsActive,
            ProductType = p.ProductType,
            
            // Mapeamento de Objetos Relacionados (Evita NullReferenceException)
            CategoryId = p.CategoryId,
            CategoryName = p.Category != null ? p.Category.Name : "Sem Categoria",
            
            SupplierId = p.SupplierId,
            SupplierName = p.Supplier != null ? p.Supplier.UserName : "Desconhecido",

            // Mapeamento da Lista de Imagens
            Images = p.Images.Select(img => new ProductImageDto 
            { 
                Id = img.Id, 
                ImageUrl = img.ImageUrl 
            }).ToList()
        }).ToList();

        // 3. Retorna a lista de DTOs limpa
        return Ok(productsDto);
    }
    
    // GET: api/products/sup
    [HttpGet("sup")]
    [Authorize(Roles = UserRoles.Supplier)]
    public async Task<ActionResult<IEnumerable<Product>>> GetSupplierProducts()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var products = await _repository.GetSupplierProducts(userId);
        return Ok(products);
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var product = await _repository.GetProductById(id);
        if (product == null || product.SupplierId != userId)
            return NotFound();
        
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    [Authorize(Roles = UserRoles.Supplier)]
    public async Task<ActionResult<Product>> CreateProduct(Product dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        dto.SupplierId = userId;
        
        await _repository.AddProduct(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    // PUT: api/products/5
    [HttpPut("{id}")]
    [Authorize(Roles = UserRoles.Supplier)]
    public async Task<IActionResult> UpdateProduct(int id, Product dto)
    {
        if (id != dto.Id)
            return BadRequest();
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var product = await _repository.GetProductById(id);
        if (product == null || product.SupplierId != userId)
            return Forbid();
        
        await _repository.UpdateProduct(dto);
        return NoContent();
    }

    // DELETE: api/products/5
    [HttpDelete("{id}")]
    [Authorize(Roles = UserRoles.Supplier)]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var product = await _repository.GetProductById(id);
        if (product == null || product.SupplierId != userId)
            return Forbid();
        await _repository.DeleteProduct(id);
        return NoContent();
    }
}