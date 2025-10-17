using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCOLL_API.Data;
using MyCOLL_API.Models;
using MyCOLL_API.Models.Dto;
using MyCOLL_API.Models.Entities;
using MyCOLL_API.Mapper;

namespace MyCOLL_API.Controllers
{
    // localhost:7183/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await dbContext.Products.ToListAsync();
            return Ok(products.Select(p => ProductMapper.EntityToDto(p)));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product is null) return NotFound();
            return Ok(ProductMapper.EntityToDto(product));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                BasePrice = dto.BasePrice,
                SellTax = dto.SellTax,
                State = dto.State,
                Quality = dto.Quality
            };
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, ProductMapper.EntityToDto(product));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product is null) return NotFound();
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateProduct(long id, [FromBody] CreateProductDto dto)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product is null) return NotFound();
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.BasePrice = dto.BasePrice;
            product.SellTax = dto.SellTax;
            product.State = dto.State;
            product.Quality = dto.Quality;
            await dbContext.SaveChangesAsync();
            return Ok(ProductMapper.EntityToDto(product));
        }
    }
}
