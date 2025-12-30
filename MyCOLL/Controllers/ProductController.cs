using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using MyCOLL.Shared.Constants;
using MyCOLL.Data.Models.Entities;
using MyCOLL.Interface;

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
    public async Task<ActionResult<IEnumerable<Product>>> GetClientProducts()
    {
        var products = await _repository.GetClientProducts();
        return Ok(products);
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
    [Authorize(Roles = UserRoles.Supplier)]
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